using System.Collections;
using System.Collections.Generic;
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
        if(target == null)
        {
            return;
        }

    rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }
/*Basic Camera Zoom with Scrollwheel
    void Update ()
    {
        if (Input.GetAxis ("Mouse ScrollWheel") > 0)
        {
//            GetComponent<Camera>().fieldOfView--;
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y-0.6f, transform.position.z+0.2f);
            transform.Rotate(-2, 0, 0);
        }
        if (Input.GetAxis ("Mouse ScrollWheel") < 0)
        {
//            GetComponent<Camera>().fieldOfView++;
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y+0.6f, transform.position.z-0.2f);
            transform.Rotate(2, 0, 0);
        }
    }*/
}