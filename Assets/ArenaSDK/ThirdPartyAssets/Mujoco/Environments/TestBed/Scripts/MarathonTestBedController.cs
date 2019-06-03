﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MLAgents;
using UnityEngine;

public class MarathonTestBedController : MonoBehaviour
{
    [Tooltip("Action applied to each motor")]
    /**< \brief Edit to manually test each motor (+1/-1)*/
    public float[] Actions;

    [Tooltip("Apply a random number to each action each framestep")]
    /**< \brief Apply a random number to each action each framestep*/
    public bool ApplyRandomActions = true;

    public bool FreezeHead = false;
    public bool FreezeHips = false;
    bool _hasFrozen;


    // Start is called before the first frame update
    void Start()
    {

    }
    void FreezeBodyParts()
    {

        var marathonAgents = FindObjectsOfType<MarathonAgent>();
        foreach (var agent in marathonAgents)
        {
            Rigidbody head = null;
            Rigidbody butt = null;
            switch (agent.name)
            {
                case "humanoid":
                    _hasFrozen = true;
                    var children = agent.GetComponentsInChildren<Rigidbody>();
                    head = children.FirstOrDefault(x=>x.name=="head");
                    butt = children.FirstOrDefault(x=>x.name=="butt");
                    break;
                default:
                    break;
            }
            if (FreezeHead && head != null)
                head.constraints = RigidbodyConstraints.FreezeAll;
            if (FreezeHead && butt != null)
                butt.constraints = RigidbodyConstraints.FreezeAll;

        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_hasFrozen)
            FreezeBodyParts();
    }
}
