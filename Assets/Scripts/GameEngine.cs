using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);
        
        Debug.Log("Health; " +healthSystem.GetHealth());
    }
    
    void Update()
    {
        
    }
}
