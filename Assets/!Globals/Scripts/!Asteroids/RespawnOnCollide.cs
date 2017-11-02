using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Respawn))]
public class RespawnOnCollide : MonoBehaviour
{
    private string colliderTag;
    private Respawn res;
    // Use this for initialization
    void Awake()
    {
        res = GetComponent<Respawn>();

    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
