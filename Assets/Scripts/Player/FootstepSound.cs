using UnityEngine;

namespace Player
{
    public class FootstepSound : MonoBehaviour
    {
        public AudioSource audioSource;
        float footstepDelay = 0.5f;
        float footstepTimer = 0.0f;

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Debug.Log("Horizontal axis: " + horizontal + " Vertical axis: " + vertical);

            // Your code to play the footstep sound goes here
            // Check if the player is walking
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                // Increment the footstep timer
                footstepTimer += Time.deltaTime;

                // If the footstep timer exceeds the delay, play the footstep sound and reset the timer
                if (footstepTimer >= footstepDelay)
                {
                    audioSource.Play();
                    footstepTimer = 0.0f;
                }
            }
            else
            {
                // Reset the footstep timer if the player is not walking
                footstepTimer = 0.0f;
            }
        }
    }
}