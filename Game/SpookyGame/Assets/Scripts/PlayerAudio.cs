using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;

    private float moving;
    private float terror;
    private GameObject[] goSkeletons;
    private GameObject UI;

    private float radius;
    private bool test;

    void Start()
    {
        // audio setup
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        moving = 0.0f;
        terror = 0.01f;
        radius = 30.0f;
        test = false;

        // grab all the skeletons for use with terror
        goSkeletons = GameObject.FindGameObjectsWithTag("Skeleton");

        UI = GameObject.Find("UI_Manager");
    }

    void Update()
    {
        if (!UI.GetComponent<GameManager>().GetPauseEnabled() && emitter.EventInstance.isValid())
        {
            UpdateWalkingSound();
            UpdateTerror();
        }
    }

    void UpdateTerror()
    {
        float temp = 0.0f;
        terror = 0.01f;
        float distance = 0.0f;

        foreach (GameObject sk in goSkeletons)
        {
            // If a skeleton is close enough, determine how close it is and return that percentage as terror
            distance = DistanceToPlayerSquared(sk);
            if (distance < radius * radius)
            {
                //print("Distance: " + Mathf.Sqrt(distance));
                temp = 1 - (radius - Mathf.Sqrt(distance)) / radius;
                // Only update terror if the current object is now the closest)
                if (temp > terror)
                {
                    terror = temp;
                    
                }
            }
        }
        // Set the Terror parameter
        //print("terror: " + terror);
        emitter.SetParameter("Terror", terror);
    }

    void UpdateWalkingSound()
    {
        // Play sounds when a movement key is pressed
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            moving = 1.0f;
        }
        else
        {
            moving = 0.0f;
        }
        // Set the moving parameter
        print("walking: " + moving);
        emitter.SetParameter("Moving", moving);
    }

    float DistanceToPlayerSquared(GameObject obj)
    {
        return (obj.transform.position - transform.position).sqrMagnitude;
    }
}
