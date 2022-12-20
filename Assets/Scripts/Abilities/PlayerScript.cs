using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject fireball1;
    public GameObject fireball2;
    public float fireballRotateSpeed;
    private GameObject fireball1Instance;
    private GameObject fireball2Instance;

    void Update()
    {
        if (fireball1Instance != null && fireball2Instance != null)
        {
            // Calculate the new position and rotation of the fireballs
            Vector3 fireball1Position = transform.position + new Vector3(Mathf.Sin(Time.time), 0, Mathf.Cos(Time.time)) * 2;
            Quaternion fireball1Rotation = Quaternion.Euler(0, Time.time * fireballRotateSpeed, 0);
            fireball1Instance.transform.SetPositionAndRotation(fireball1Position, fireball1Rotation);

            Vector3 fireball2Position = transform.position + new Vector3(Mathf.Sin(Time.time), 0, -Mathf.Cos(Time.time)) * 2;
            Quaternion fireball2Rotation = Quaternion.Euler(0, Time.time * -fireballRotateSpeed, 0);
            fireball2Instance.transform.SetPositionAndRotation(fireball2Position, fireball2Rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateAbility();
        }
    }
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
        }
    }

    public void ActivateAbility()
    {
        // Instantiate the fireballs and set their position and rotation relative to the player
        fireball1Instance = Instantiate(fireball1, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        fireball2Instance = Instantiate(fireball2, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
    }
}

