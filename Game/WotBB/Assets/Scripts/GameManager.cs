using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Following this guide:
    // https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/

    private StudioEventEmitter pause;
    private StudioEventEmitter unpause;

    public bool GetPauseEnabled()
    {
        return this.GetComponentInChildren<Canvas>().enabled;
    }

    void Start()
    {
        this.GetComponentInChildren<Canvas>().enabled = false;

        pause = GameObject.Find("PauseSound").GetComponent<FMODUnity.StudioEventEmitter>();
        unpause = GameObject.Find("UnpauseSound").GetComponent<FMODUnity.StudioEventEmitter>();
    }

    void Update()
    {
        ScanForPauseInput();
    }

    void ScanForPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }

    /// <summary>
    /// Toggles the pause menu with either the 'Escape' key or 'Resume' button.
    /// </summary>
    public void TogglePauseMenu()
    {
        if(this.GetComponentInChildren<Canvas>().enabled)
        {
            unpause.Play();
            this.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pause.Play();
            this.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
