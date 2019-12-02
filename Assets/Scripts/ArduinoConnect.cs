using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoConnect : MonoBehaviour
{
    // Set to right COM#
    public SerialPort serial = new SerialPort("COM7", 9600);
    // Variable to keep track of light state
    private bool lightOn = false;

    // Open port upon start up
    void Start() {
        if (serial.IsOpen == false) {
	 	    serial.Open();
	    }
    }
    
    public void OnButtonLED()
     {
         Debug.Log("Button was pressed!");

	     if (lightOn == false) {
		    Debug.Log("Light on");
	   	    // "A" turns light on (see ArduinoLED.ino)
	        serial.Write("A");
		    lightOn = true;
	     } else {
		    Debug.Log("Light off");
		    // Not "A" turns light off (see ArduinoLED.ino)
		    serial.Write("Off");
		    lightOn = false;
	     }
     }

    
}
