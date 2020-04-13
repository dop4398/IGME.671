using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;

    private int value;

    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        value = 2;
    }

    void Update()
    {
        if (emitter.EventInstance.isValid())
        {
            if (Time.timeScale == 1.0f)
            {
                value = 2; // full volume
            }
            else if (Time.timeScale == 0.0f)
            {
                value = 1; // quieter if paused
            }
            // Set the Ambient parameter
            emitter.SetParameter("Ambient", value);
        }
    }
}
