using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;
    private GameObject UI;

    private int value;

    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        UI = GameObject.Find("UI_Manager");
        value = 2;
    }

    void Update()
    {
        if (emitter.EventInstance.isValid())
        {
            if (!UI.GetComponent<GameManager>().GetPauseEnabled())
            {
                value = 2; // full volume
            }
            else
            {
                value = 1; // paused snapshot
            }
            // Set the Ambient parameter
            emitter.SetParameter("GameState", value);
        }
    }
}
