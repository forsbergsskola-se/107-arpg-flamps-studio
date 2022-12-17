using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;

    private Transform _rigTransform;

    private void Start()
    {
        _rigTransform = transform.parent;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        _rigTransform.position =
            Vector3.Lerp(_rigTransform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }
}