using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions
{
    public class PlayerScript : MonoBehaviour
    {
        public float acceleration = 20f;
        public float rotationSpeed = 360f;

        private Rigidbody2D rigid;
        
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Rotate();
        }

        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            rigid.AddForce(transform.up * inputV * acceleration);
        }
        void Rotate()
        {
            float inputH = Input.GetAxis("Horizontal");
            //Vector3.back, angle
            transform.Rotate(Vector3.back, rotationSpeed * inputH * Time.deltaTime);
        }
    }
}