using UnityEngine;

public class DisappearingObject : MonoBehaviour
{
    // Distance at which the player can interact with the object
    public float interactionDistance = 2.0f;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is close enough to the object
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < interactionDistance)
        {
            // Check if the player has pressed the 'E' key
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Destroy the object
                Destroy(gameObject);
            }
        }
    }
}
