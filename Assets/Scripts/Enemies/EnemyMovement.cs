using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour, IMovement
    {
        private Vector3 _curDest;
        private float _curDistThreshold;

        private bool _isNavigating;
        private NavMeshAgent _navMeshAgent;

        public bool IsNavigating
        {
            get => _isNavigating;
            set
            {
                if (_isNavigating != value)
                {
                    Debug.Log("isNavigating Changed");
                    OnNavigationStateChanged?.Invoke(value);
                }

                _isNavigating = value;
            }
        }

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!IsNavigating) return;

            if (IsDistanceWithinThreshold(transform.position, _curDest, _curDistThreshold)) IsNavigating = false;
        }


        public event IMovement.NavigationStateChange OnNavigationStateChanged;

        public void MoveNear(Vector3 destination, float distanceThreshold)
        {
            AttemptMoveNear(destination, distanceThreshold);
        }


        private void AttemptMoveNear(Vector3 destination, float distanceThreshold)
        {
            if (!_navMeshAgent.SetDestination(destination))
                return;

            IsNavigating = true;
            _curDest = destination;
            _curDistThreshold = distanceThreshold;
        }

        // I know Unity has similar functions but I'm not sure about their performance impacts and cant be arsed to check
        public static bool IsDistanceWithinThreshold(Vector3 a, Vector3 b, float distThreshold)
        {
            return (a - b).sqrMagnitude < Mathf.Pow(distThreshold, 2); // sqrMagnitude because it's faster
        }
    }
}