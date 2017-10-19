using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;
namespace AI
{
    public class Flee : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            if (force == null)
            {
                return force;
            }
            Vector3 desiredForce = transform.position - target.position;
            if (desiredForce.magnitude > stoppingDistance)
            {
                desiredForce = desiredForce.normalized * weight;
                force = desiredForce - owner.velocity;

                #region GizmosGL
                GizmosGL.color = Color.red;
                GizmosGL.AddLine(transform.position, transform.position + force);
                GizmosGL.color = Color.red;
                GizmosGL.AddLine(transform.position, transform.position + desiredForce);
                #endregion
            }
            return force;


        }

    }
}