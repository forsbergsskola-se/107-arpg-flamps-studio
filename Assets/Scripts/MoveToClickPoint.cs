// MoveToClickPoint.cs

using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Animator anim;
    [SerializeField] private float distanceToTarget = 2f;

    private Transform _target;
    private Camera _mainCam;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _mainCam = Camera.main;
        player = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        anim.SetFloat(IsWalking, player.velocity.magnitude / player.speed);

        GetDestination();

        if (_target != null)
        {
            var between = _target.position - transform.position;

            if (between.magnitude <= distanceToTarget)
                return;

            player.SetDestination(_target.position);
        }
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