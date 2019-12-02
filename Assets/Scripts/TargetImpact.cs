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
            Debug.Log("Bullet hit target");
            Transform t = other.transform;
            Destroy(other.gameObject);
            Instantiate(bulletHolePrefab, new Vector3(t.position.x, t.position.y, this.gameObject.transform.position.z - 0.02f), Quaternion.identity);
        }
    }

}
