using Player;
using UnityEngine;

public class PlayerTestEngine : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private float _regenTimer;
    public int damageReceived = 10;
    public int healthRestored = 10;
    [SerializeField] private int amount2Regen = 1;

    public HealthBar healthbar;

    
    [SerializeField] private LevelSystem _levelSystem;

    private void Start()
    {
        //Test HealthSystem
        _healthSystem = new HealthSystem(100, 10);
        healthbar.SetHealthMax(_healthSystem.GetHealth());
    }

    private void Update()
    {
        //FOR TESTING PURPOSES... REMOVE IN FINAL GAME
        if (Input.GetKeyDown(KeyCode.T)) //cast spell, use mana
        {
            _healthSystem.Damage(damageReceived); //The mana used to cast a spell
        }
        //FOR TESTING PURPOSES... REMOVE IN FINAL GAME
        if (Input.GetKeyDown(KeyCode.H))
        {
            _healthSystem.Heal(healthRestored);
        }

        _regenTimer += Time.deltaTime;
        if (_regenTimer >= 1)
        {
            _healthSystem.Regen(amount2Regen);
            _regenTimer = 0;
        }

        healthbar.SetHealthCurrent(_healthSystem.GetHealth());
        
        //FOR MONSTERS TO ACCESS PLAYER HEALTHSYSTEM
        /*HealthSystem GetHealthSystem()
        {
            return _healthSystem;
        }*/
    }
}
