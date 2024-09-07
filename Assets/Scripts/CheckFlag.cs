using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlag : MonoBehaviour
{
    public bool EnterText;
    public bool TextOver;
    public GameObject field;
    // Start is called before the first frame update
    void Start()
    {
        field.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other){
        if (other.CompareTag("Flag")){
            field.SetActive(true);

        }
    }
}
