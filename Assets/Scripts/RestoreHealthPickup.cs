using Player;
using UnityEngine;

public class RestoreHealthPickup : MonoBehaviour
{
    [SerializeField] private int _restoreAmount = 50; // Amount of health to restore when picked up
    [SerializeField] private float _pickupRange = 2.0f; // Range at which the pickup can be collected
    [SerializeField] private string _playerTag = "Player"; // Tag that represents the player character

    private void Update()
    {
        // Check if the player is within range of the pickup
        GameObject player = GameObject.FindWithTag(_playerTag);
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= _pickupRange)
            {
                // If the player is within range, try to restore their health
                HealthSystem healthSystem = player.GetComponent<HealthSystem>();
                if (healthSystem != null)
                {
                    healthSystem.Heal(_restoreAmount);
                    Destroy(gameObject); // Remove the pickup from the game
                }
            }
        }
    }
}