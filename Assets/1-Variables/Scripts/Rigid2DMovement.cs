using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigid2DMovement : MonoBehaviour
{
    // <acess-specifier> <data-type> (optional initialization) 
    public int lives = 3;
    public float rotationSpeed = 360f;
    public float movementSpeed = 20f;
    public float acceleration = 50f;
    public float deceleration = 20;
    private Rigidbody2D rigid; //default value null



    // Use this for initialization
    // <acess-specifier> <return-type> <function-name>
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Rotation();
        Decelerate();
      
    }

    void Movement()
    {
        float inputV = Input.GetAxis("Vertical");

        rigid.AddForce(transform.right * inputV * movementSpeed);

       
    }

    void Rotation()
    {
        float inputH = Input.GetAxis("Horizontal");
        transform.rotation *= Quaternion.AngleAxis(inputH * rotationSpeed * Time.deltaTime, -Vector3.forward);
    }

    void Decelerate()
    {
        rigid.velocity += -rigid.velocity * deceleration * Time.deltaTime;
    }

}

