using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
public GameObject DeathCam;
public GameObject MainCam;
    void Start()
    {
        MainCam.SetActive(true);
        DeathCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Evil") )
        {
            MainCam.SetActive(false);
            DeathCam.SetActive(true);
        }
    }
}