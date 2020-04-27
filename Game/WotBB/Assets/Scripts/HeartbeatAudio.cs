using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class HeartbeatAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;
    public GameObject[] goSkeletons;
    private GameObject UI;
    private float radius;
    private float terror;

    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        terror = 0.01f;
        radius = 30.0f;

        goSkeletons = GameObject.FindGameObjectsWithTag("SkeletonPosition");
        UI = GameObject.Find("UI_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!UI.GetComponent<GameManager>().GetPauseEnabled() && emitter.EventInstance.isValid())
        {
            UpdateTerror();
            emitter.SetParameter("GameState", 2.0f);
        }
        else
        {
            UpdateTerror();
            emitter.SetParameter("GameState", 1.0f);
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
                temp = 0.1f + (radius - Mathf.Sqrt(distance)) / radius;
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

    float DistanceToPlayerSquared(GameObject obj)
    {
        return Mathf.Abs(Mathf.Pow(obj.transform.position.x - transform.position.x, 2) + Mathf.Pow(obj.transform.position.z - transform.position.z, 2));
    }
}
