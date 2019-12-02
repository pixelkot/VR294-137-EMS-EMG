using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;

    public GameObject handgun;
    public GameObject shotgun;

    public bool holdingGun = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (handgun.GetComponent<OVRGrabbable>().isGrabbed || shotgun.GetComponent<OVRGrabbable>().isGrabbed)
        {
            holdingGun = true;
            Debug.Log("grabbed gun");
        } else
        {
            Debug.Log("gun dropped");
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
