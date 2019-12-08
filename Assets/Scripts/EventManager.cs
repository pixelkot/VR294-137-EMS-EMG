using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // UI1: Choose weapon.
    public GameObject UI1;
    // UI2: Shoot target.
    public GameObject UI2;

    // Gun gameobjects.
    public GameObject handgun;
    public GameObject shotgun;

    // Flag if a gun is currently held.
    public bool holdingGun = false;

    // Arduino: Set to right COM#
    public SerialPort serial = new SerialPort("COM7", 9600);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Flag: Gun Held? @ flag
        if (handgun.GetComponent<OVRGrabbable>().isGrabbed || shotgun.GetComponent<OVRGrabbable>().isGrabbed)
        {
            holdingGun = true;
        }
        else
        {
            holdingGun = false;
        }

        // Flag: Gun Held? @ UI
        if (holdingGun)
        {
            UI1.SetActive(false);
            UI2.SetActive(true);
        }
        else
        {
            UI1.SetActive(true);
            UI2.SetActive(false);
        }
    }
}
