using UnityEngine;
using UnityEngine.AI;
    
public class MoveToClickPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Animator anim;
    [SerializeField] private float distanceToTarget = 2f;
    [SerializeField] private float threshold = 1f;
    [SerializeField] private GameObject markerPrefab; // Add this field
    
    private Transform target;
    private Camera mainCam;
    private GameObject marker; // Add this field
        
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

        // Check if the distance between the player and the marker is less than the threshold
        if (marker != null)
        {
            float distance = Vector3.Distance(transform.position, marker.transform.position);
            if (distance < threshold)
            {
                // Destroy the marker
                Destroy(marker);
            }
        }
    }


    private void GetDestination()
    {
        if (!Input.GetMouseButtonDown(1)) 
            return;
        
        if (!Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out var hit)) 
            return;
            
        if(hit.collider.CompareTag("GoTo")) //This means we hit a follow Target
        {
            Debug.Log("Target assigned : "+hit.transform.gameObject.name); 
            target = hit.transform;
        }
        else
        {
            target = null;
            player.SetDestination(hit.point);
            
            // Destroy the previous marker
            if (marker != null)
            {
                Destroy(marker);
            }
            
            // Instantiate the marker prefab at the destination point, 1 unit above the ground
            marker = Instantiate(markerPrefab, hit.point + Vector3.up * 0.5f, Quaternion.identity);

        }
    }
}

