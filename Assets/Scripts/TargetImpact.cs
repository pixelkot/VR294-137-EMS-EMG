using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetImpact : MonoBehaviour
{
    // Bullet hole prefab.
    public GameObject bulletHolePrefab;

    // Upon bullet collision, render bullet hole @ collision.transform && destroy bullet.
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
