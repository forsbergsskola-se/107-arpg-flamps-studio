// MoveToClickPoint.cs

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public static class Foo
{
    public static bool TryGetComponentInParent<T>(this Component self, out T component)
    {
        component = self.GetComponentInParent<T>();
        return component != null;
    }
} 

namespace Player
{
    
    public class Chaseable : MonoBehaviour{}
    
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveToClickPoint : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent player;
        [SerializeField] private Animator anim;
        public float distanceToTarget = 2f;
    
        public Transform target;
        private Camera mainCam;
        [SerializeField] private Vector3 _playerDestination;

        public Vector3 PlayerDestination
        {
            set
            {
                _playerDestination = value;
                destinationUpdated = true;
            }
        }
        public bool destinationUpdated; // added flag
        
        void Awake() 
        {
            mainCam = Camera.main;
            player = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            anim.SetFloat("isWalking", player.velocity.magnitude/player.speed);

            GetDestination();

            if (target != null)
            {
                var between = target.position - transform.position;
            
                if(between.magnitude <= distanceToTarget)
                    return;
            
                player.SetDestination(target.position);
            }
            else if (destinationUpdated) // added check
            {
                player.SetDestination(_playerDestination);
                destinationUpdated = false;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void GetDestination()
        {
            if (!Input.GetMouseButtonDown(1)) 
                return;
        
            if (!Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out var hit)) 
                return;
            
            if(hit.collider.TryGetComponentInParent<Chaseable>(out var foo)) //This means we hit a follow Target
            {
                Debug.Log("Target assigned : "+hit.transform.gameObject.name);
                FollowTarget(hit);
            }
            else
            {
                WalkToPoint(hit);
            }
        }

        private void WalkToPoint(RaycastHit hit)
        {
            StopFollow();
            PlayerDestination = hit.point;
        }

        private void StopFollow()
        {
            target = null;
        }

        private void FollowTarget(RaycastHit hit)
        {
            target = hit.transform;
        }
    }
}

