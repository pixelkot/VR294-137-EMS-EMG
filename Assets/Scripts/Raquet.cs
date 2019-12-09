using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquet : MonoBehaviour
{
    public Material[] mats = new Material[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        GetComponent<Renderer>().material = mats[Random.Range(0, mats.Length)];
    }
}
