
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMove : MonoBehaviour, IMovement
    {
        private NavMeshAgent _navMeshAgent;
        private bool _isNavigating = false;
        
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void BeginMove(Vector3 destination)
        {
            if (_navMeshAgent.SetDestination(destination))
                _isNavigating = true;

        }

        private void Update()
        {
            if (_isNavigating && )
            {
                
            }
        }

        public bool MoveTo(Vector3 destination, float distanceThreshold)
        {
            
        }
    }
}