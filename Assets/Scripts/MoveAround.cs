using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

using Random = UnityEngine.Random;

public class MoveAround : MonoBehaviour
{
    public GameObject navTree;
    public GameObject goal;
    public GameObject hideFrom;
    private List<Transform> areas = new();
    private NavMeshAgent agent;
    private double tickTime = 0;
    private double raycastDebounce = 0;
    private bool doNewStep = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in navTree.transform) {
            areas.Add(child);
        }

        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(NavStep());
    }

    void Update() {
        if (Physics.Raycast(transform.position, hideFrom.transform.position - transform.position, out var _)
        && Time.time - raycastDebounce > 5) {
            doNewStep = true;
            raycastDebounce = Time.time;
        }
    }
    
    IEnumerator NavStep() {
        while (true) {
            Transform area = areas[Random.Range(0, areas.Count - 1)];
            Vector3 lower = area.position - area.localScale / 2;
            Vector3 upper = area.position + area.localScale / 2;
            goal.transform.position = new Vector3(Random.Range(lower.x, upper.x), Random.Range(lower.y, upper.y), Random.Range(lower.z, upper.z));
            agent.destination = goal.transform.position;
            tickTime = Time.time;
            yield return new WaitUntil(() => {
                var shouldDoNewStep = doNewStep;
                doNewStep = false;
                return Time.time - tickTime > 15 || shouldDoNewStep;
            });
        }
    }
}
