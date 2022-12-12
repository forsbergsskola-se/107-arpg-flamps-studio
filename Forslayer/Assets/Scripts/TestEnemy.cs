using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float area = 8f;

        private Vector3 destination;

        private void Start()
        {
            GetNewDestination();
        }
        
        private void Update()
        {
            if ((destination - agent.transform.position).magnitude <= 1f)
            {
                GetNewDestination();
            }
        }

        private void GetNewDestination()
        {
            var pos = (new Vector2(transform.position.x, transform.position.z) + Random.insideUnitCircle) * area;
            destination = transform.position + new Vector3(pos.x, 0, pos.y);
            Debug.DrawLine(transform.position, transform.position + destination, Color.magenta, 2f);
            agent.SetDestination(destination);
        }
    }
