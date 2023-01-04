// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;
    
public class MoveToClickPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Animator anim;
    [SerializeField] public static float distanceToTarget = 2f;
    
    public Transform target;
    private Camera mainCam;
    public Vector3 playerDestination;
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
            player.SetDestination(playerDestination);
            destinationUpdated = false;
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
            playerDestination = hit.point;
            destinationUpdated = true; // set flag
        }
    }

    public void SetPlayerDestination(Vector3 destination) // added method
    {
        playerDestination = destination;
        destinationUpdated = true;
    }
}

