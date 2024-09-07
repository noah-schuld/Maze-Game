using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

using Random = UnityEngine.Random;

public class BadDuck : MonoBehaviour
{
    public GameObject goal;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update() {
        agent.destination = goal.transform.position;
    }
}
