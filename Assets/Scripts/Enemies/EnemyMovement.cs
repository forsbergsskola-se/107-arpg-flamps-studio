using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour, IMovement
    {
        private NavMeshAgent _navMeshAgent;
        
        public bool IsNavigating { get; private set; }
        
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            
        }
        
        public void UpdateDestination(Vector3 destination, float stopAtDistance)
        {
            _navMeshAgent.stoppingDistance = stopAtDistance;
            
            if (_navMeshAgent.SetDestination(destination))
                IsNavigating = true;
        }
        
        private void Update()
        {
            if (_navMeshAgent.pathPending) return;
            if (!(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)) return;
            if (_navMeshAgent.hasPath && _navMeshAgent.velocity.sqrMagnitude != 0f) return;
            
            OnPathComplete();
        }

        private void OnPathComplete()
        {
            IsNavigating = false;
        }
    }
}