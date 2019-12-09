using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
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

    // Arduino serial port.
    public SerialPort serial = new SerialPort("COM4", 9600);

    void Start() {
      if (serial.IsOpen == false) {
        serial.Open();
      }
    }

    // If gun is grabbed && shot => trigger shot animation && Shoot().
    void Update()
    {
        if (shotgun.GetComponent<OVRGrabbable>().isGrabbed) {
          Debug.Log("shotty grabbed");
          // Detect gun being about to be shot -> send signal to Arduino.
          if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f) {
            // Send signal to Arduino.
            Debug.Log("Sending signal to Arduino");
          }
          // Trigger pressend all the way -> fire.

          if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {

            Debug.Log("Firing gun");
            serial.Write("B");
            serial.Write("A");
            Shoot();
          }
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
