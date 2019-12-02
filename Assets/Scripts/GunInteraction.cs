using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInteraction : MonoBehaviour
{
    public bool holdingGun = false;
    private GameObject gun = null;

    public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);

    public GameObject EventManagerGO;
    private EventManager EventManagerScript = null;

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript = EventManagerGO.GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingGun)
        {
            SimpleShoot gunScript = gun.GetComponent<SimpleShoot>();

            if (indexTriggerState > 0.9f && oldIndexTriggerState < 0.9f)
                gunScript.ShootTrigger();

            if (handTriggerState < 0.9f)
            {
                Release();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("gun"))
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.9f && !holdingGun)
            {
                // Pick up gun.
                Debug.Log("Grabbing gun");
                Grab(other.gameObject);

            }

        }
    }

    void Grab(GameObject obj)
    {
        holdingGun = true;
        gun = obj;

        gun.transform.parent = transform;

        gun.transform.localPosition = holdPosition;
        gun.transform.localEulerAngles = holdRotation;

        gun.GetComponent<Rigidbody>().useGravity = false;
        gun.GetComponent<Rigidbody>().isKinematic = true;

        EventManagerScript.holdingGun = true;

    }

    void Release()
    {
        gun.transform.parent = null;

        Rigidbody rigidbody = gun.GetComponent<Rigidbody>();

        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;

        rigidbody.velocity = OVRInput.GetLocalControllerVelocity(controller);

        EventManagerScript.holdingGun = false;
        holdingGun = false;
        gun = null;
    }
}
