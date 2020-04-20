using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class SkeletonAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;
    private GameObject player;
    private GameObject UI;
    private float radius;

    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        //player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.Find("UI_Manager");
        //radius = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UI.GetComponent<GameManager>().GetPauseEnabled() && emitter.EventInstance.isValid())
        {
            //UpdateRattle();
            emitter.SetParameter("GameState", 2);
            //print("GameState: 2");
        }
        else
        {
            emitter.SetParameter("GameState", 1);
        }
    }

    void UpdateRattle()
    {
        float temp = 0;
        float distance = DistanceToObjectSquared(player);

        if (distance < radius * radius)
        {
            temp = 1 - (radius - Mathf.Sqrt(distance)) / radius;
            // Set the distance to the player
            emitter.SetParameter("DistanceToPlayer", temp);
            print("Distance to player: " + temp);
        }
    }

    float DistanceToObjectSquared(GameObject obj)
    {
        return (obj.transform.position - transform.position).sqrMagnitude;
    }
}
