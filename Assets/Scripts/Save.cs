using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Save : MonoBehaviour
{
    private int _currentMana = ManaSystem._manaCurrent;
    private int _PlayerMana = ManaSystem._manaMax;
    private int _playerLevel = LevelSystem.level;
    private int _xp = LevelSystem._curXp;
    public GameObject player;
    readonly int _maxHealth = HealthSystem._healthCurrent;
    readonly int _currentHealth = HealthSystem._healthCurrent;
      
      
          
      


       void Start()
           {
               if (Input.GetKeyDown(KeyCode.S))
               {
                   Vector3 playerPosition = player.transform.position;
                   PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
                   PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
                   PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
                   PlayerPrefs.SetInt("MaxHealth", _maxHealth);
                   PlayerPrefs.SetInt("currentXP", _xp);
                   PlayerPrefs.SetInt("playerLevel", _playerLevel);
                   PlayerPrefs.SetInt("playerHealth", _currentHealth);
                   PlayerPrefs.SetInt("currentMana", _currentMana);
                   PlayerPrefs.SetInt("PlayerMana", _PlayerMana);
                   PlayerPrefs.Save();
                   Debug.Log("playerPosition " + playerPosition + ", PlayerHealth " + _currentHealth +
                             ", moneyCollected " + _maxHealth);
               }
           }
}
