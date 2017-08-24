using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;
        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }



        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;
            //check if velocity is going up
            if (vel.y > 0)
            //if it is going up off the table
            {
                //cap velocity
                vel.y = 0;
                //not letting it go there
            }

            //if the velocity's speed is less than the stop speed
            if (vel.magnitude < stopSpeed)
            //Magnitude is the hypotenuse between 2 vector points.
            {
                //cancel out velocity
                vel = Vector3.zero; //stopping the ball by setting its velocity to 0
            }

            rigid.velocity = vel;
        }
        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce/*luke*/(dir *impactForce, ForceMode.Impulse);
        }
    }
}