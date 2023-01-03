using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTransparency : MonoBehaviour
{
public GameObject player;
public Camera mainCamera;

void Update()
{
    //Calculate direction from player to camera
    Vector3 direction = mainCamera.transform.position - player.transform.position;

    //Cast a ray from player to camera
    Ray ray = new Ray(player.transform.position, direction);
    RaycastHit hit;

    //If ray hits this game object, make it transparent
    if (Physics.Raycast(ray, out hit))
    {
        if (hit.collider.gameObject == gameObject)
        {
            Debug.Log("Make transparent");
            //gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        }
    }
    //If ray does not hit this game object, make it opaque
    else
    {
        //gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1f);
    }
}

}
