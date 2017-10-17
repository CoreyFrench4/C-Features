using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Charger : Enemy
    {
        public float impactForce = 10f;
        public float knockback = 10f;
        public GameObject dashParticles;
        // Use this for initialization
       
        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

    }
}
