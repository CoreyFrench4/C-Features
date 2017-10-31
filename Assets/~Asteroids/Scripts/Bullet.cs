using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string triggerTag = "Asteroids";

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == triggerTag)
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
