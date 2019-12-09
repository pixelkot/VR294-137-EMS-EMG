using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class goalieSave : MonoBehaviour
{
    /*
    // Audio
    public AudioSource audioSource;
    public AudioClip drumSound;
    */

    public GameObject soccerBall;
    public Transform player;
    private bool ballCounter;


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
        kickBall();
    }

    void kickBall()
    {
        ballCounter = false;
        ballKick();
    }

    void ballKick()
    {
        if (!ballCounter)
        {    // Set so you will only throw 1 ball at a time
            GameObject ball = Instantiate(soccerBall, GameObject.Find("BallKickPoint").transform.position, transform.rotation);
            //ball.GetComponent<Rigidbody>().velocity = BallisticVel(player);
            ballCounter = true;
        }
    }
    /*
    var ballToThrow : GameObject;
     var player : Transform;    
     private var ballCounter : boolean;
 
     function Update()
    {

        throwBall();
    }

    function throwBall()
    {

        ballCounter = false;    // Rest to false so another ball can be thrown
        ballThrow();
    }

    function ballThrow()
    {

        if (!ballCounter)
        {    // Set so you will only throw 1 ball at a time

            var ball: GameObject = Instantiate(ballToThrow, GameObject.Find("BallThrowPoint").transform.position, transform.rotation);
            ball.rigidbody.velocity = BallisticVel(player);
            ballCounter = true;
        }
    }

    // Work out the velocity and angle to the player for the Balls trajectory
    function BallisticVel(target: Transform): Vector3 {
     
         var dir = target.position - transform.position;    // Get target direction
    var h = dir.y;                                                        // Get height difference
    dir.y = 0;                                                            // Retain only the horizontal direction
         var dist = dir.magnitude;                                            // Get horizontal distance
    dir.y = dist;                                                        // Set elevation to 45 degrees
         dist += h;                                                            // Correct for different heights
         var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude);
         return vel* dir.normalized;                                        // Returns Vector3 velocity
         */


private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "drums")
        {


            //audioSource.PlayOneShot(drumSound, 0.7F);

            //write to arduino
            serial.Write("B");
            serial.Write("A");

        }
    }
}
