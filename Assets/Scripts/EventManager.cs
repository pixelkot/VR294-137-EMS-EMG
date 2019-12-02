using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;

    public GameObject handgun;
    public GameObject shotgun;

    public bool holdingGun = false;

    // Set to right COM#
    public SerialPort serial = new SerialPort("COM7", 9600);

    // Start is called before the first frame update
    void Start()
    {
        if (serial.IsOpen == false)
        {
            serial.Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (handgun.GetComponent<OVRGrabbable>().isGrabbed || shotgun.GetComponent<OVRGrabbable>().isGrabbed)
        {
            holdingGun = true;
        }
        else
        {
            holdingGun = false;
        }

        if (holdingGun && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
        {
            serial.Write("A");
        }

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
