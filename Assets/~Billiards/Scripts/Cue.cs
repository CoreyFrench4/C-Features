using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Billiards
{
    public class Cue : MonoBehaviour
    {
        public Ball targetBall; // targets the ball selected
        public float minPower = 0f; //min power
        public float maxPower = 20f; //max power
        public float maxDistance = 5f; //max cue drag back distance

        private float hitPower; // the final calculated hit power to fire the ball
        private Vector3 aimDirection; // direction you want to hit the ball
        private Vector3 prevMousePos; // the mouse when you left click
        private Ray mouseRay; // the ray cast of the mouse
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }
            if (Input.GetMouseButton(0))
            {
                Drag();
            }
            else
            {
                Aim();
            }
            if (Input.GetMouseButtonUp(0))
            {
                Fire();
            }
                    
        }
        void OnDrawGizmos()
        {
            Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(targetBall.transform.position, targetBall.transform.position + aimDirection * hitPower);
        }
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        public void Activate()
        {
            Aim();
            gameObject.SetActive(true);
        }

        void Aim()

        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                //Obtain direction from the cue's position to the raycast's hit point
                Vector3 dir = transform.position - hit.point;
                //Convert direction to angle in degrees
                float angle = Mathf.Atan2(dir.x, dir.x) * Mathf.Rad2Deg;//Radius to Degrees
                //Rotate towards that angle
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                //position cue to the ball's position
                transform.position = targetBall.transform.position;
           
            }
            
                

            
        }
        void Drag()
        {
            //store target ball's position in smaller variable
            Vector3 targetPos = targetBall.transform.position;
            // Get mouse position in world units
            Vector3 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Calculate distance from previous mouse position to the current mouse position
            float distance = Vector3.Distance(prevMousePos, currMousePos);
            // Clamp the distance between 0 - maxDistance
            distance = Mathf.Clamp(distance, 0, maxDistance);
            //Calculate a percentage for the distance
            float distPercentage = distance / maxDistance;
            // use percentage of distance to map to the minPower - maxPower values
            hitPower = Mathf.Lerp(minPower, maxPower, distPercentage);
            //position the cue back using distance
            transform.position = targetPos - transform.forward * distance;
            //Get direction to target ball
            aimDirection = (targetPos - transform.position).normalized;
        }
        void Fire()
        {
            //hit the ball with dir and pwr
            targetBall.Hit(aimDirection, hitPower);
            // Deactivate the Cue when done
            Deactivate();
        }
    }
}
