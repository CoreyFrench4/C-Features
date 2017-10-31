using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = 0.2f;

        public float shootTimer = 0f;
        // Use this for initialization
        void Shoot()
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootRate)
            {
                if (Input.GetKey(KeyCode.Space)) 
                {
                    Shoot();
                    shootTimer = 0;
                }
            }
        }
    }
}
