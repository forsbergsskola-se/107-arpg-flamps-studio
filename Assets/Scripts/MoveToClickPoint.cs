// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;
    
public class MoveToClickPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Animator anim;
    [SerializeField] private float distanceThreshold = 2f;
    
    private Transform _target;
    private Camera _mainCam;
        
    void Awake() 
    {
        _mainCam = Camera.main;
        player = GetComponent<NavMeshAgent>();
    }
        
    void Update()
    {
        
        anim.SetFloat("isWalking", player.velocity.magnitude / player.speed);

        GetDestination();

        if (_target == null) return;
    }

    private void GetDestination()
    {
        if (!Input.GetMouseButtonDown(1)) 
            return;
        
        if (!Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition), out var hit)) 
            return;
            
        if (hit.collider.CompareTag("GoTo")) // This means we hit a follow Target
        {
            Debug.Log("Target assigned : " + hit.transform.gameObject.name); 
            _target = hit.transform;
        }
        else
        {
            _target = null;
            player.SetDestination(hit.point);
        }
    }
}
