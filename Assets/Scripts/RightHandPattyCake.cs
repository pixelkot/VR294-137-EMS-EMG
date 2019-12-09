using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

// Patty cake?
public class RightHandPattyCake : MonoBehaviour
{

    public Material[] mats = new Material[5];

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Arduino serial port.
    public SerialPort serial = new SerialPort("COM4", 9600);


    private float convertedTime = 200;
    public float smoothTime;
    private float smooth;

    private bool rotInside = true;
    private bool rotOutside = false;
    private bool goInside = false;
    private bool goOutside = false;
    private bool goForward = false;
    private bool goBackward = false;

    public float speed = 0.001f;


    public Transform insideTransform;
    public Transform originTransform;
    public Transform forwardTransform;


    // Start is called before the first frame update
    void Start()
    {
        if (serial.IsOpen == false)
        {
            serial.Open();
        }

        audioSource = GameObject.Find("CustomHandRight").GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (rotInside)
        {
            transform.Rotate(0, 0, Time.deltaTime * -25.0f);

            Debug.Log("in rotInside");
            if (transform.rotation.z >= 0.714)
            {
                Debug.Log("Done inside");
                rotInside = false;
                goInside = true;
            }

        }
        else if (rotOutside)
        {
            transform.Rotate(0, 0, Time.deltaTime * 25.0f);
            Debug.Log(transform.rotation.z);


            Debug.Log("in rotInside");
            if (transform.rotation.z <= 0.6463031)
            {
                Debug.Log("Done inside");
                rotOutside = false;
                goForward = true;
            }
        }
        else if (goInside)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, insideTransform.position, move);

            Debug.Log("in goInside");
            if (transform.position == insideTransform.position)
            {
                Debug.Log("finished inside");
                goInside = false;
                goOutside = true;
            }
        }
        else if (goOutside)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, originTransform.position, move);
            if (transform.position == originTransform.position)
            {
                goOutside = false;
                rotOutside = true;
            }
        }
        else if (goForward)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, forwardTransform.position, move);

            if (transform.position == forwardTransform.position)
            {
                goForward = false;
                goBackward = true;
            }
        }
        else if (goBackward)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, originTransform.position, move);
            if (transform.position == originTransform.position)
            {
                goBackward = false;
                rotInside = true;
            }
        }

    }

    public void OnCollisionEnter(Collision other)
    {
        serial.Write("B");
        serial.Write("A");
        audioSource.PlayOneShot(audioClip);
        GetComponent<Renderer>().material = mats[Random.Range(0, mats.Length)];
    }
}

