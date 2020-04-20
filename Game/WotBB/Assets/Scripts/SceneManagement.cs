using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using UnityEngine.EventSystems;

public class SceneManagement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private StudioEventEmitter hoverOver;
    private StudioEventEmitter hoverOff;
    private StudioEventEmitter select;
    string button;
    // Start is called before the first frame update
    void Start()
    {
        hoverOver = GameObject.Find("HoverOver").GetComponent<FMODUnity.StudioEventEmitter>();
        hoverOff = GameObject.Find("HoverOff").GetComponent<FMODUnity.StudioEventEmitter>();
        select = GameObject.Find("Select").GetComponent<FMODUnity.StudioEventEmitter>();

        button = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && button != "")
        {
            select.Play();

            if (button == "PlayButton")
            {
                //if (Input.GetMouseButtonUp(0))
                SceneManager.LoadScene(2);
            }
            else if (button == "MenuButton")
            {
                //if (Input.GetMouseButtonUp(0))
                SceneManager.LoadScene(0);
            }
            else if (button == "CreditsButton")
            {
                //if (Input.GetMouseButtonUp(0))
                SceneManager.LoadScene(1);
            }
            else if (button == "ResumeButton")
            {
                //if (Input.GetMouseButtonUp(0))
                GameObject.FindGameObjectWithTag("UI").GetComponent<GameManager>().TogglePauseMenu();
            }
            else if (button == "QuitButton")
            {
                //if (Input.GetMouseButtonUp(0))
                Application.Quit();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        button = name;
        hoverOver.Play();
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        button = "";
        hoverOff.Play();
    }
}
