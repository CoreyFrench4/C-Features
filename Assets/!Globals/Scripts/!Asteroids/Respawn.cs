using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float respawnTime = 3f;
    public Renderer rend;
    public Vector3 spawnPos;
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    // Use this for initialization
    void Start()
    {
        spawnPos = transform.position;
    }

    // Update is called once per frame
   void Spawn()
    {
        StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        rend.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        transform.position = spawnPos;
        rend.enabled = true;
            
    }
}
