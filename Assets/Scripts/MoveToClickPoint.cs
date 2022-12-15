// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;
    
public class MoveToClickPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Animator anim;
    [SerializeField] private float distanceToTarget = 2f;
    
    private Transform target;
    private Camera mainCam;
        
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
        }
    }
}
