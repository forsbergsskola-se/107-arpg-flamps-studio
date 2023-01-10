using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;
    
    private Transform rigTransform;

    void Start()
    {
    rigTransform = this.transform.parent;
    }
    void FixedUpdate ()
    {
        if(rigTransform == null || target == null)
        {
            return;
        }

        rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }

}