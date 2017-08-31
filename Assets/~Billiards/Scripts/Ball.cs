using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    public class Ball : MonoBehaviour
    {
        public Text countText;
        public Text winText;
        private int count;

        public float stopSpeed = 0.2f;
        private Rigidbody rigid;

        private Cue cue;

        void Awake()
        {
            cue = GetComponent<Cue>();
        }
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
             
                cue.Activate();
            }

            rigid.velocity = vel;
        }
        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce/*luke*/(dir *impactForce, ForceMode.Impulse);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pocket"))
            {
                Destroy(this.gameObject);
                count = count + 1;
                SetCountText();
            }
        }

        void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
            if (count >= 15)
            {
                winText.text = "You Win!";
            }
        }
    }

}