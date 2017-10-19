using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace AI
{
    [RequireComponent(typeof(AiAgent))]
    public class SteeringBehaviour : MonoBehaviour
    {
        public float weight = 8f;
        public Vector3 force;
        public AiAgent owner;


        protected virtual void Awake()
        {
            owner = GetComponent<AiAgent>();
        }
        public virtual Vector3 GetForce()
        {
            return Vector3.zero;
        }
    }
}