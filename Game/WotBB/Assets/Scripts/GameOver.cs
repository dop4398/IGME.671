using System.Collections;
using System.Collections.Generic;
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
            GameObject.Find("SkeletonCollision").GetComponent<FMODUnity.StudioEventEmitter>().Play();
            SceneManager.LoadScene(3);
        }
    }

}
