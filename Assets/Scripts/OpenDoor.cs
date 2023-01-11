using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Distance at which the player can interact with the object
    public float interactionDistance = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is close enough to the object
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < interactionDistance)
        {
            // Check if the player has pressed the 'N' key
            if (Input.GetKeyDown(KeyCode.N))
            {
                // Destroy the object
                Destroy(gameObject);
            }
        }
    }
}
