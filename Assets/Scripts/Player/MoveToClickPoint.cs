using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class MoveToClickPoint : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent player;
        [SerializeField] private Animator anim;
        [SerializeField] private float distanceToTarget = 2f;
        [SerializeField] private float threshold = 1f;
        [SerializeField] private GameObject markerPrefab; // Add this field
    
        private Transform _target;
        private Camera _mainCam;
        private GameObject _marker; // Add this field
        
        void Awake() 
        {
            _mainCam = Camera.main;
            player = GetComponent<NavMeshAgent>();
        }
        
        void Update()
        {
            anim.SetFloat("isWalking", player.velocity.magnitude/player.speed);

            GetDestination();

            if (_target != null)
            {
                var between = _target.position - transform.position;
            
                if(between.magnitude <= distanceToTarget)
                    return;
            
                player.SetDestination(_target.position);
            }

            // Check if the distance between the player and the marker is less than the threshold
            if (_marker != null)
            {
                float distance = Vector3.Distance(transform.position, _marker.transform.position);
                if (distance < threshold)
                {
                    // Destroy the marker
                    Destroy(_marker);
                }
            }
        }


        private void GetDestination()
        {
            if (!Input.GetMouseButtonDown(1)) 
                return;
        
            if (!Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition), out var hit)) 
                return;
            
            if(hit.collider.CompareTag("GoTo")) //This means we hit a follow Target
            {
                Debug.Log("Target assigned : "+hit.transform.gameObject.name); 
                _target = hit.transform;
            }
            else
            {
                _target = null;
                player.SetDestination(hit.point);
            
                // Destroy the previous marker
                if (_marker != null)
                {
                    Destroy(_marker);
                }
            
                // Instantiate the marker prefab at the destination point, 1 unit above the ground
                _marker = Instantiate(markerPrefab, hit.point + Vector3.up * 0.5f, Quaternion.identity);

            }
        }
    }
}

