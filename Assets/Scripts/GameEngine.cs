using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    HealthSystem healthSystem;
    void Start()
    {
        this.healthSystem = new HealthSystem(100);
        
        Debug.Log("Health; " +healthSystem.GetHealth());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            healthSystem.Damage(10);
            Debug.Log("Damaged: " + healthSystem.GetHealth());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            healthSystem.Heal(10);
            Debug.Log("Healed: " + healthSystem.GetHealth());
        }
    }
}
