using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject Player;
    int _maxHealth = HealthSystem._healthCurrent;
    int _currentHealth = HealthSystem._healthCurrent;
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load Game...");
            
            float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
            float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
            float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
            Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
            _maxHealth = PlayerPrefs.GetInt("maxHealth");
            _currentHealth = PlayerPrefs.GetInt("playerHealth");
            Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + _currentHealth + "moneyCollected" +
                      _currentHealth);

            Player.transform.position = playerPosition;
        }
    }
}
