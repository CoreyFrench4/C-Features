﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PaperMarioClone
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float walkSpeed = 20f;
        public float runSpeed = 30f;
        public float jumpHeight = 10f;
        public bool isRunning = false;
        private bool jumpInstant = false;
        public bool isGrounded
        {
            get { return controller.isGrounded; }
        }

        private CharacterController controller;
        private Vector3 gravity;
        private Vector3 movement;
        private bool jump = false;


        // Use this for initialization
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isRunning)
                movement *= runSpeed;
            else
                movement *= walkSpeed;
            if (isGrounded)
            {
                gravity = Vector3.zero;
                if(jump)
                {
                    gravity.y = jumpHeight;
                    jump = false;
                }
            }
            
                else
            {
                gravity += Physics.gravity * Time.deltaTime;
            }
            // ADDED THIS
            if (jumpInstant)
            {
                gravity.y = jumpHeight;
                jumpInstant = false;
            }
            //
            movement += gravity;
            controller.Move(movement * Time.deltaTime);
        }

        public void Jump(bool instant = false)
        {
            if (instant) // << CHANGED THIS
                jumpInstant = true;
            else
                jump = true;
        }

        public void Move(float inputH, float inputV)
        {
            // Store input in vector
            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            // Transform direction of movement based on input
            movement = transform.TransformDirection(inputDir);
        }
    }
}
