using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    // how much the ball should be knocked back
    public int magnitude = 5000;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Arduino serial port.
    public SerialPort serial = new SerialPort("COM4", 9600);

    // Start is called before the first frame update
    void Start()
    {
        if (serial.IsOpen == false)
        {
            serial.Open();
        }

        audioSource = GameObject.Find("10540_Tennis_racket_V2_L3").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        serial.Write("B");
        serial.Write("A");

        audioSource.PlayOneShot(audioClip);
        // calculate force vector
        var force = transform.position - other.transform.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
        gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
    }
}
