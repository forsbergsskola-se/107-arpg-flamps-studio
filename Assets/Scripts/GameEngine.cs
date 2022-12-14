using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    HealthSystem healthSystem;
    float regenTimer = 0;
    public int amount2Regen = 1;
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
        
        regenTimer += Time.deltaTime;
        if (regenTimer >= 1)
        {
            healthSystem.Regen(amount2Regen);
            regenTimer = 0;
            Debug.Log("Regened: " + healthSystem.GetHealth());
        }
    }
}
