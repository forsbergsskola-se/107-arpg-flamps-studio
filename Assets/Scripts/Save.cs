using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject player;
    readonly int _maxHealth = HealthSystem._healthCurrent;
    readonly int _currentHealth = HealthSystem._healthCurrent;
      
      
          
      


       void Start()
           {
              
               Vector3 playerPosition = player.transform.position;
               PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
               PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
               PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
               PlayerPrefs.SetInt("MaxHealth", _maxHealth);
               PlayerPrefs.SetInt("playerHealth", _currentHealth);
               PlayerPrefs.Save();
               Debug.Log("playerPosition " + playerPosition + ", PlayerHealth " + _currentHealth + ", moneyCollected " + _maxHealth); 
           }
}
