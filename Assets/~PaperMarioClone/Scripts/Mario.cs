using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PaperMarioClone
{
    [RequireComponent(typeof(PlayerController))]
    public class Mario : MonoBehaviour
    {
        private PlayerController pC;
        private float rayDistance;
        private Ray stompRay;
        // Use this for initialization

        private void OnDrawGizmos()
        {
            RecalculateRay();
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(stompRay.origin, stompRay.origin + stompRay.direction * rayDistance);
        }


        void Start()
        {
            pC = GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!pC.isGrounded)
            {
                CheckStomp();
            }
        }
        void RecalculateRay()
        {
            stompRay = new Ray(transform.position, Vector3.down);
        }

        void CheckStomp()
        {
            RecalculateRay();
        {
                stompRay = new Ray(transform.position, Vector3.down);
            }
        }
    }
}