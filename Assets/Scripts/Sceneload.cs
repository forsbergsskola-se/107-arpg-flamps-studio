using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneload : MonoBehaviour
{
    private int _currentMana = ManaSystem._manaCurrent;
    private int _PlayerMana = ManaSystem._manaMax;
    private int _playerLevel = LevelSystem.level;
    private int _xp = LevelSystem._curXp;
    public GameObject Player;
    int _maxHealth = HealthSystem._healthCurrent;
    int _currentHealth = HealthSystem._healthCurrent;
    MoveToClickPoint moveToClickPoint;
    
    void Awake()
    {
        moveToClickPoint = GetComponent<MoveToClickPoint>();
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitGame() {
        Application.Quit();
    }

    public void Loadgame()
    {
        Debug.Log("Load Game...");
            
        float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
        moveToClickPoint.SetPlayerDestination(playerPosition);
        moveToClickPoint.target = null;
        _maxHealth = PlayerPrefs.GetInt("maxHealth");
        _currentHealth = PlayerPrefs.GetInt("playerHealth");
        _xp = PlayerPrefs.GetInt("currentXP");
        _playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        _PlayerMana = PlayerPrefs.GetInt("PlayerMana");
        _currentMana = PlayerPrefs.GetInt("currentMana");
        Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + _currentHealth + "moneyCollected" +
                  _currentHealth);

        Player.transform.position = playerPosition;
    }
}
