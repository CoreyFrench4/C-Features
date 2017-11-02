﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller2D : MonoBehaviour
    {
        public float accelerate = 20f;
        public float jumpHeight = 10f;
        public float rayDistance = 1f;
        public LayerMask hitLayer;
        public bool isGrounded = false;

        private Rigidbody2D rigid2D;

        // Use this for initialization
        void Awake()
        {
            rigid2D = GetComponent<Rigidbody2D>();
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position,
                transform.position + -transform.up * rayDistance);
        }
        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,
                -transform.up, rayDistance, hitLayer);
            if (hit.collider != null)
                isGrounded = true;
            else
                isGrounded = false;
        }

        // Handles movement
        public void Move(float inputH)
        {
            rigid2D.AddForce(transform.right * inputH * accelerate);
        }

        // Allows for jump when called
        public void Jump()
        {
            
             rigid2D.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse); 
        }
    }
}
