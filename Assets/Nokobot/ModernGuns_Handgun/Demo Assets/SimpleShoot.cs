using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
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

    public bool singleSignalSent = false;

    // Arduino serial port.
    public SerialPort serial = new SeerialPort("COM4", 9600);

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (serial.IsOpen == false) {
            serial.Open();
        }
    }

    void reset() {
      serial.Write("A");
    }

    void Update()
    {
        // If gun is grabbed.
        if (handgun.GetComponent<OVRGrabbable>().isGrabbed) {
          // Detect gun geing about to be shot -> send signal to Arduino.
          if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) > 0.1f || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) > 0.1f) {
            if (!singleSignalSent) {
              signalSignalSent = true;
              Debug.Log("Sending signal to Arduino");
              // B = Intensity up, A = Intensity down
              serial.Write("B");
              reset();
            }
          }
          // Trigger pressed all the way -> Fire
          if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            Debug.Log("Firing gun");

            GetComponent<Animator>().SetTrigger("Fire");
          }
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

        singleSignalSent = false;
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
