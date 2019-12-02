using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetImpact : MonoBehaviour
{
    public GameObject bulletHolePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            Transform t = other.transform;
            Destroy(other.gameObject);
            Instantiate(bulletHolePrefab, new Vector3(t.position.x + 0.01f, t.position.y, t.position.z), Quaternion.identity);
        }
    }

}
