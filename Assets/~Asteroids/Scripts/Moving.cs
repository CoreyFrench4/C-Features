using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class Moving : MonoBehaviour
    {
        public float accel = 50f;
        public float rotSpeed = 360f;

        private Rigidbody2D rigi;

        // Use this for initialization
        void Awake()
        {
            rigi = GetComponent<Rigidbody2D>();
        }
        void Start()
        {

        }
        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            rigi.AddForce(transform.up * inputV * accel);
        }
        void Rotation()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back, rotSpeed * inputH * Time.deltaTime);
        }
        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Rotation();
        }
    }
}