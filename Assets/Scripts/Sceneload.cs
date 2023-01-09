using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneload : MonoBehaviour
{
    public GameObject Player;
    public LevelSystem levelSystem;
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
        HealthSystem._healthMax = PlayerPrefs.GetInt("MaxHealth");
        HealthSystem._healthCurrent = PlayerPrefs.GetInt("playerHealth");
        levelSystem.CurrentXp = PlayerPrefs.GetInt("currentXP");
        levelSystem.CurrentLevel = PlayerPrefs.GetInt("playerLevel");
        ManaSystem._manaMax = PlayerPrefs.GetInt("PlayerMana");
        ManaSystem._manaCurrent = PlayerPrefs.GetInt("currentMana");
        Debug.Log("playerPosition " + playerPosition + ", PlayerHealth " + HealthSystem._healthCurrent +
                  "maxhealth " + HealthSystem._healthMax + "currentxp: " + levelSystem.CurrentXp + " Level: " +
                  levelSystem);

        Player.transform.position = playerPosition;
    }
}
