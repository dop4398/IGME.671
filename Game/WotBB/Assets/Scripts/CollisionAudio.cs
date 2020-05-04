using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField]

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameObject.Find("WoodCollision").GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
        else if(collision.gameObject.CompareTag("Stone"))
        {
            GameObject.Find("StoneCollision").GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
        else if (collision.gameObject.CompareTag("Metal"))
        {
            GameObject.Find("MetalCollision").GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }
}
