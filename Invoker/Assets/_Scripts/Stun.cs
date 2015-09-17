﻿using UnityEngine;
using System.Collections;

public class Stun : MonoBehaviour
{
    private float duration = 0;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start ()
    {
        navMeshAgent.Stop();
    }
    
    void Update()
    {
        // Wait x seconds before destroying the stun script.
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            navMeshAgent.Resume();
            Destroy(this);
        }
    }

    // Accessors and Mutators
    public float Duration
    {
        get { return duration; }
        set { duration = value; }
    }
}
