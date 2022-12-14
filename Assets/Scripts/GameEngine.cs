using UnityEngine;

public class GameEngine : MonoBehaviour
{
    HealthSystem _healthSystem;
    float _regenTimer;
    public int amount2Regen = 1;

    public HealthBar healthbar;
    void Start()
    {
        this._healthSystem = new HealthSystem(100);
        healthbar.SetHealthMax(_healthSystem.GetHealth());
        
        Debug.Log("Health; " +_healthSystem.GetHealth());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _healthSystem.Damage(10);
            Debug.Log("Damaged: " + _healthSystem.GetHealth());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _healthSystem.Heal(10);
            Debug.Log("Healed: " + _healthSystem.GetHealth());
        }
        
        _regenTimer += Time.deltaTime;
        if (_regenTimer >= 1)
        {
            _healthSystem.Regen(amount2Regen);
            _regenTimer = 0;
            Debug.Log("Regened: " + _healthSystem.GetHealth());
        }
        
        healthbar.SetHealthCurrent(_healthSystem.GetHealth());
    }
}
