using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelLocation;

    public float shotPower = 100f;

    public AudioSource audioSource;
    public AudioClip shotgunShot;

    public GameObject shotgun;

    void Start()
    {
    }

    void Update()
    {
        if (shotgun.GetComponent<OVRGrabbable>().isGrabbed && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
        {
            GetComponent<Animation>()["Reload"].wrapMode = WrapMode.Once;
            GetComponent<Animation>().Play("Reload");
            Shoot();
        }
    }


    void Shoot()
    {
        audioSource.PlayOneShot(shotgunShot, 0.7F);
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
    }
}
