using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Save : MonoBehaviour
{

    public GameObject player;
    public LevelSystem levelSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
            PlayerPrefs.SetInt("MaxHealth", HealthSystem._healthMax);
            PlayerPrefs.SetInt("currentXP", levelSystem.CurrentXp);
            PlayerPrefs.SetInt("playerLevel", levelSystem.CurrentLevel);
            PlayerPrefs.SetInt("playerHealth", HealthSystem._healthCurrent);
            PlayerPrefs.SetInt("currentMana", ManaSystem._manaCurrent);
            PlayerPrefs.SetInt("PlayerMana", ManaSystem._manaMax);
            PlayerPrefs.Save();
            Debug.Log("playerPosition " + playerPosition + ", PlayerHealth " + HealthSystem._healthCurrent +
                      "maxhealth " + HealthSystem._healthMax + "currentxp: " + levelSystem.CurrentXp + " Level: " +
                      levelSystem);
        }
    }
}