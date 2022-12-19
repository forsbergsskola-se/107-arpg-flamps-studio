using UnityEngine;

public class HealthTestEngine : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private float _regenTimer;
    public int damageReceived = 10;
    public int healthRestored = 10;
    [SerializeField] private int amount2Regen = 1;

    public HealthBar healthbar;

    private void Start()
    {
        _healthSystem = new HealthSystem(100);
        healthbar.SetHealthMax(_healthSystem.GetHealth());

        Debug.Log("Health; " + _healthSystem.GetHealth());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _healthSystem.Damage(damageReceived); // Damage taken by player
            Debug.Log("Damaged: " + _healthSystem.GetHealth());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _healthSystem.Heal(healthRestored); // 
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