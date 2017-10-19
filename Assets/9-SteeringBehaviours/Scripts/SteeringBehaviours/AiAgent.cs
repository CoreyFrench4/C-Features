using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AiAgent : MonoBehaviour
    {
        public Vector3 force; //total force calculated from behaviours
        public Vector3 velocity; // direction of travel and speed
        public float maxVelocity = 100f; // max amount 
        public float maxDistance = 10f;
        public bool freezeRotation = false; // do we freze rotation

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        // Use this for initialization
        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }
        void ComputeForces()
        {
            force = Vector3.zero;
            for (int i = 0; i < behaviours.Count; i++)
            {
                SteeringBehaviour behaviour = behaviours[i];
                if (behaviour.isActiveAndEnabled == false)
                {
                    continue;
                }
                force = force + behaviour.GetForce();
                if (force.magnitude > maxVelocity)
                {
                    force = force.normalized * maxVelocity;
                    break;
                }

            }
        }
        void ApplyVelocity()
        {
            velocity = velocity + force * Time.deltaTime;
            if (velocity.magnitude > maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }
            if (velocity.magnitude > 0)
            {
                transform.position = transform.position + velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ComputeForces();
            ApplyVelocity();
        }

    }
}

