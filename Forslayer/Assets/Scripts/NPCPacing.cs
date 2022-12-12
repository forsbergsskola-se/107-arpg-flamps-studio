using UnityEngine;

public class NPCPacing : MonoBehaviour
{


    void Start()
    {
        transform.position = new Vector3(2.0f, 1.0f, 3.0f);
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, 0.5f) * Time.deltaTime;
    }
}