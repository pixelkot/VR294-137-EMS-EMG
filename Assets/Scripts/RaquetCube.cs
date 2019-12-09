using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetCube : MonoBehaviour
{
    public CubeFollower cubeFollerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCubeFollowerPrefab();
    }

    void SpawnCubeFollowerPrefab()
    {
        var follower = Instantiate(cubeFollerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }
}
