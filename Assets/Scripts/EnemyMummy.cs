using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMummy : MonoBehaviour
    {
        public GameObject player;


        [SerializeField] private NavMeshAgent agent;
        //[SerializeField] private float area = 0f;

        private Vector3 destination;

        private void Start()
        {
            // Initialize the destination to the player's current position
            destination = player.transform.position;
            //GetNewDestination();
        }

        private void Update()
        {
            // Check if the player object is assigned
            if (player != null)
            {
                // Update the destination to the player's current position
                Vector3 destination = player.transform.position;
                // Update the destination for the NavMeshAgent
                agent.SetDestination(destination);
            }
            else
            {
                // Get a new destination
                GetNewDestination();
            }
        }


        private void GetNewDestination()
        {
            // Set the destination to the player's position
            destination = player.transform.position;
            // Update the destination for the NavMeshAgent
            agent.SetDestination(destination);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            // Check if the enemy has collided with the player
            if (collision.gameObject.tag == "Player")
            {
                // Get the PlayerTestEngine component from the player object
                PlayerTestEngine playerTestEngine = collision.gameObject.GetComponent<PlayerTestEngine>();
                // Check if the component is assigned
                if (playerTestEngine != null)
                {
                    // Get the player's health system
                    HealthSystem healthSystem = playerTestEngine.GetHealthSystem();
                    // Damage the player's health system
                    healthSystem.Damage(0);
                    // Update the player's health bar
                    playerTestEngine.healthbar.SetHealthCurrent(healthSystem.GetHealth());
                }

                // Get the LevelSystem component from the player object
                LevelSystem levelSystem = collision.gameObject.GetComponent<LevelSystem>();
                // Check if the component is assigned
                if (levelSystem != null)
                {
                    // Add 10 XP to the player's level system
                    levelSystem.AddXp(20);
                }

                // Destroy the enemy
                Destroy(gameObject);
            }
        }
    }