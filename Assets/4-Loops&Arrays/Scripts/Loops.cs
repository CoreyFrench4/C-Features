using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LoopsArrays
{
    public class Loops : MonoBehaviour
    {
        public string message = "print this";
        public GameObject[] spawnPrefabs;
        public float spawnRadius = 5f;
        public int spawnAmount = 10;
        public float printTime = 2f;
        public float frequency = 3f;
        public float amplitude = 5f;
        private float timer = 0;
        // Use this for initialization
        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        void Start()
        {
            SpawnObjects();
        }
        // Update is called once per frame
        void Update()
        {

        }

        void SpawnObjects()
        {
            for (int i = 0; i < spawnAmount; i++)
            {

                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                GameObject clone = Instantiate(randomPrefab);
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                rend.material.color = new Color(r, g, b);

                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                clone.transform.position = randomPos;
            }
        }
    }
}