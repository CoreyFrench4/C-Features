using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Cannon : MonoBehaviour
    {
        public Transform barrel;
        public GameObject projectilePrefab;
        public Vector3 targetPos; //position of targetEnemy
        public Vector3 barrelPos;
        public Quaternion barrelRot;
        public Vector3 fireDirection;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Fire(Enemy targetEnemy)
        {
            targetPos = targetEnemy.transform.position;
            barrelPos = barrel.position;
            barrelRot = barrel.rotation;
            fireDirection = targetPos - barrelPos;
            barrelRot = Quaternion.LookRotation(fireDirection, Vector3.up);
            GameObject clone = Instantiate(projectilePrefab,barrelPos, barrelRot);
            Projectile p = clone.GetComponent<Projectile>();
            p.direction = fireDirection;
        }
    }
}