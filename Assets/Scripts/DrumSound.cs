using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class DrumSound : MonoBehaviour
{
    // Audio
    public AudioSource audioSource;
    public AudioClip drumSound;

    // Arduino serial port.
    public SerialPort serial = new SerialPort("COM4", 9600);

   


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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "drums")
        {
            audioSource.PlayOneShot(drumSound, 0.7F);

            //write to arduino
            serial.Write("B");
            serial.Write("A");

        }
    }
}
