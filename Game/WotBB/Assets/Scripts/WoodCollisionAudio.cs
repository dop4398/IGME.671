using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class WoodCollisionAudio : MonoBehaviour
{
    private StudioEventEmitter emitter;
    private GameObject player;
    private GameObject[] trees;
    private float radius;
    private Vector3 currentCollision;
    bool anyCollision;

    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        player = GameObject.FindGameObjectWithTag("Player");
        trees = GameObject.FindGameObjectsWithTag("Obstacle");

        radius = 3;
        anyCollision = false;
        currentCollision = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        anyCollision = false;
        foreach (GameObject tree in trees)
        {
            if(DistanceToPlayerSquared(tree) <= radius * radius)
            {
                anyCollision = true;
                if(currentCollision != tree.transform.position)
                {
                    currentCollision = tree.transform.position;
                    emitter.Play();
                } 
            }
        }
        if(!anyCollision)
        {
            currentCollision = new Vector3(0, 0, 0);
        }
    }

    float DistanceToPlayerSquared(GameObject obj)
    {
        return Mathf.Abs(Mathf.Pow(obj.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(obj.transform.position.z - transform.position.z, 2));
    }
}
