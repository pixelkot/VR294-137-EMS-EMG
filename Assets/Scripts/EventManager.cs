using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;

    public bool holdingGun = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(holdingGun)
        {
            UI1.SetActive(false);
            UI2.SetActive(true);
        } else
        {
            UI1.SetActive(true);
            UI2.SetActive(false);
        }
    }
}
