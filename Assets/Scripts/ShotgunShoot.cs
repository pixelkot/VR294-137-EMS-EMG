using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    // Bullet prefab.
    public GameObject bulletPrefab;

    // Bullet origin position.
    public Transform barrelLocation;

    // Bullet speed.
    public float shotPower = 100f;

    // Audio. 
    public AudioSource audioSource;
    public AudioClip shotgunShot;

    // Gun GO.
    public GameObject shotgun;

    // If gun is grabbed && shot => trigger shot animation && Shoot().
    void Update()
    {
        if (shotgun.GetComponent<OVRGrabbable>().isGrabbed && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
        {
            GetComponent<Animation>()["Reload"].wrapMode = WrapMode.Once;
            GetComponent<Animation>().Play("Reload");
            Shoot();
        }
    }

    // Shoot bullet && play accompanying audio.
    void Shoot()
    {
        audioSource.PlayOneShot(shotgunShot, 0.7F);
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
    }
}
