using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    public float time = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code (if any)
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            audioSource.Play();
            time = Random.Range(5, 10);
        }
        else if (time > 0)
        {
            time = time - Time.deltaTime;
        }
    }
}