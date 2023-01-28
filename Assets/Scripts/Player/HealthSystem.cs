using UnityEngine;

public class HealthSystem
{
    public static int _healthCurrent;
    public static int _healthMax;

    public HealthSystem(int healthMax, int healthPerLevel)
    {
        _healthMax = healthMax;
        _healthCurrent = healthMax;
        //_healthPerLevel = healthPerLevel; active when using playerlevelsystem
    }
    
    public int GetHealth()
    {
        return _healthCurrent;
    }

    public void Damage(int damageAmount)
    {
        _healthCurrent -= damageAmount;
        if (_healthCurrent < 0) _healthCurrent = 0;
    }

    public void Heal(int healAmount)
    {
        _healthCurrent += healAmount;
        if (_healthCurrent > _healthMax) _healthCurrent = _healthMax;
    }

    public void Regen(int regenAmount)
    {
        if (!IsDead())
        {
            _healthCurrent += regenAmount;
            if (_healthCurrent > _healthMax) _healthCurrent = _healthMax;
        }
    }

    public bool IsDead()
    {
        if (_healthCurrent <= 0)
        {
            Debug.Log("You Died");
            PauseGame();
            GameOver();
        }
        return _healthCurrent <= 0;
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over. Press Q to Quit or any other key to Restart");
        string input = Input.inputString;
        if (input.Contains("q") || input.Contains("Q"))
        {
            Application.Quit();
        }
        else
        {
            Debug.Log("Restart Game");
            // Restart the game here
        }
    }

    void PauseGame()
    {
        Debug.Log("Restart Game");
        Time.timeScale = 0;
    }
    
    public void IncreaseMaxHealth(int healthAmount)
    {
        Debug.Log("Level Up new max health");
        _healthMax += healthAmount;
    }
}
