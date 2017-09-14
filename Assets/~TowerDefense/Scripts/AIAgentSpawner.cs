using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class AIAgentSpawner : MonoBehaviour
    {
        public GameObject aiAgentPrefab; // Prefab of the agent
        public Transform target; //Target of each AI Agent that is spawned
        public float spawnRate = 1f; //Rate of spawn
        public float spawnRadius = 1f; //Radoius of spawn
        // Use this for initialization
        void Start()
        {
            // InvokeRepeating(function, time, repeatRate)
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            // Draw a sphere to show spawn area
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        void Spawn()
        {
            GameObject clone = Instantiate(aiAgentPrefab);
            Vector3 rand = Random.insideUnitSphere;
            rand.y = 0;
            clone.transform.position = transform.position + rand * spawnRadius;
            AIAgent aiAgent = clone.GetComponent<AIAgent>();
            aiAgent.target = target;
        }
    }
}