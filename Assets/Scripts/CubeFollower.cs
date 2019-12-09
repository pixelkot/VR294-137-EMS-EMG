using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollower : MonoBehaviour
{
    public RaquetCube raquetCube;
    private Rigidbody rigidbody;
    private Vector3 velocity;

    private float sensitivity = 100f;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 destination = raquetCube.transform.position;
        rigidbody.transform.rotation = transform.rotation;
        velocity = (destination - rigidbody.transform.position) * sensitivity;
        rigidbody.velocity = velocity;
        transform.rotation = raquetCube.transform.rotation;
    }

    public void SetFollowTarget(RaquetCube go)
    {
        raquetCube = go;
    }
}
