using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Ctrl K+D

namespace Variabmles
{

    public class Movement : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public float rotationSpeed = 20f;
        public Vector3 rotateDir = Vector3.forward;




        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float inputH = Input.GetAxis("Horizontal");

            float inputV = Input.GetAxis("Vertical");
            transform.position += transform.right * inputV * movementSpeed * Time.deltaTime;

            transform.eulerAngles += rotateDir * -inputH * rotationSpeed * Time.deltaTime;
        }
    }

}

