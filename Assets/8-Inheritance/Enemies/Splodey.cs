using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Splodey : Enemy
    {
        public float explosionRadius= 20f;
        public float impactForce = 50f;
        public float explosionTimer = 0f;
        public float explosionRate = 5;
        public GameObject explosionParticles;
      
        // Use this for initialization
        
        protected override void Attack()
        {
            if (explosionTimer >= explosionRate)
            {
                Splode();
            }
        }
        protected override void Update()
        {
            base.Update();
            explosionTimer += Time.deltaTime;
            

        }

        public void Splode()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider hit in hits)
            {
                Health h = hit.GetComponent<Health>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                    rigi.AddExplosionForce(impactForce, transform.position, explosionRadius);
                    OnAttackEnd();
                }
            }
            
        }
        protected override void OnAttackEnd()
        {
            explosionTimer = 0f;
        }
    }
}
