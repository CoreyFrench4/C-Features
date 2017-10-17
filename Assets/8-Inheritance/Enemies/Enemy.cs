using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        public Transform target;
        public int health;
        public int damage;
        public float attackRadius = 5f;
        public float attackRate = 5f;
        public float attackDuration = 2f;

        public float attackTimer = 0f;

        protected NavMeshAgent nav;
        protected Rigidbody rigi;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigi = GetComponent<Rigidbody>();
        }
        // Use this for initialization
        void Start()
        {

        }
       

        // Update is called once per frame
       protected virtual void Update()
        {
            if (target == null)
                return;
            nav.SetDestination(target.position);
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackRate)
            {
                float distance = Vector3.Distance(transform.position, target.position);

                if(distance <= attackRadius)
                {
                    Attack();
                    attackTimer = 0f;
                    StartCoroutine(AttackDelay(attackDuration));
                }
            }

        }
        protected virtual void Attack()
        {

        }
        IEnumerator AttackDelay(float delay)
        {
            nav.Stop();
            yield return new WaitForSeconds(delay);
            if (nav.isOnNavMesh)
                nav.Resume();

        }
        protected virtual void OnAttackEnd()
        {

        }
    }
}
