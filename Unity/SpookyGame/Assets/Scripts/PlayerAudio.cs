using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;

    private int moving;
    private float terror;
    private GameObject[] goSkeletons;
    private GameObject UI;

    private float radius;

    void Start()
    {
        // audio setup
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        moving = 0;
        terror = 0.01f;
        radius = 30;

        // grab all the skeletons for use with terror
        goSkeletons = GameObject.FindGameObjectsWithTag("Skeleton");

        UI = GameObject.Find("UI_Manager");
    }

    void Update()
    {
        if(!UI.GetComponent<GameManager>().GetPauseEnabled() && emitter.EventInstance.isValid())
        {
            UpdateWalkingSound();
            UpdateTerror();
        }
    }

    void UpdateTerror()
    {
        float temp = 0;
        terror = 0.01f;
        float distance = 0;

        foreach (GameObject skeleton in goSkeletons)
        {
            // If a skeleton is close enough, determine how close it is and return that percentage as terror
            distance = DistanceToPlayerSquared(skeleton);
            if (distance < radius * radius)
            {
                temp = 1 - (radius - Mathf.Sqrt(distance)) / radius;
                // Only update terror if the current object is now the closest)
                if (temp > terror)
                {
                    terror = temp;
                    print("terror: update");
                }
            } 
        }
        // Set the Terror parameter
        emitter.SetParameter("Terror", terror);
    }

    void UpdateWalkingSound()
    {
        // Play sounds when a movement key is pressed
        if ((Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)) && Time.timeScale == 1.0f)
        {
            moving = 1;
        }
        else
        {
            moving = 0;
        }
        // Set the Ambient parameter
        emitter.SetParameter("Moving", moving);
    }

    float DistanceToPlayerSquared(GameObject obj)
    {
        return (obj.transform.position - transform.position).sqrMagnitude;
    }
}
