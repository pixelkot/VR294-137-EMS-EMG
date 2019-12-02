using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    // Handgun bullet.
    public GameObject bulletPrefab;

    // GOs for animation.
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    // GOs for bullet shot direction.
    public Transform barrelLocation;
    public Transform casingExitLocation;

    // Bullet speed.
    public float shotPower = 100f;

    // Gun GO.
    public GameObject handgun;

    // Audio.
    public AudioSource audioSource;
    public AudioClip handgunShot;
    public float shotPower = 100f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        // Gun Grabbed && Shot => trigger animation. 
        if (handgun.GetComponent<OVRGrabbable>().isGrabbed && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }
    }

    // Shooting logic.
    void Shoot()
    {
        // Flash animation.
        GameObject tempFlash;
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        // Audio upon shot.
        audioSource.PlayOneShot(handgunShot, 0.7F);
    }

    // Shot animation on gun. 
    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
