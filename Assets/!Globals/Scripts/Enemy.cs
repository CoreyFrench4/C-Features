using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritence
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        public Transform target;
        public float damage = 50f;
        public float attackDuration = 2f;
        public float attackRange = 2f;

        protected NavMeshAgent nav;
        protected Rigidbody rigid;

        private float attackTimer = 0f;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }
        protected virtual void Attack()
        {

        }
        protected virtual void OnAttackEnd()
        {

        }
        IEnumerator AttackDelay(float delay)
        {
            //Above the delay happens immediatly
            nav.Stop();
            yield return new WaitForSeconds(delay);
            //Do this stuff after delay
            nav.Resume();
            OnAttackEnd();
        }
     
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        protected virtual void Update()
        {
            //Update the nav destination
            nav.SetDestination(target.position);
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if(distance <= attackRange)
                {
                    StartCoroutine(AttackDelay(attackDuration));
                    Attack();
                    attackTimer = 0f;
                }

            }

        }
    }
}
