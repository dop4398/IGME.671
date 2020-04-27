using System.Collections;
using System.Collections.Generic;
using FMOD;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    private bool on;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Skeleton") && on)
        {
            GameObject[] rattlers = GameObject.FindGameObjectsWithTag("RattleAudio");
            GameObject.Find("HeartbeatAudio").GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("GameState", 0.0f);
            GameObject.Find("Ambient Audio Source").GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("GameState", 0.0f);

            foreach (GameObject r in rattlers)
            {
                r.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("GameState", 0.0f);
            }

            GameObject.Find("SkeletonCollision").GetComponent<FMODUnity.StudioEventEmitter>().Play();
            GameObject.Find("DeathSound").GetComponent<FMODUnity.StudioEventEmitter>().Play();

            SceneManager.LoadScene(3);
        }
    }

}
