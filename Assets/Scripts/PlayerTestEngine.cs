using Player;
using UnityEngine;

public class PlayerTestEngine : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private float _regenTimer;
    public int damageReceived = 10;
    public int healthRestored = 10;
    [SerializeField] private int amount2Regen = 1;
    
    private ManaSystem _manaSystem;
    //private float _regenTimer;
    public int manaCost = 10;
    public int manaRefill = 10;
    [SerializeField] private int mana2Regen = 1;

    public HealthBar healthbar;
    public ManaBar manaBar;
    
    [SerializeField] private LevelSystem _levelSystem;

    private void Start()
    {
        //Test HealthSystem
        _healthSystem = new HealthSystem(100, 10);
        healthbar.SetHealthMax(_healthSystem.GetHealth());
        
        //Test ManaSystem
        _manaSystem = new ManaSystem(100);
        manaBar.SetManaMax(_manaSystem.GetMana());
    }

    private void Update()
    {
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
        
        if (Input.GetKeyDown(KeyCode.Z)) //cast spell, use mana
        {
            _manaSystem.manaUsed(manaCost); //The mana used to cast a spell
        }

        if (Input.GetKeyDown(KeyCode.N)) //use potion, refill mana
        {
            _manaSystem.manaRestore(manaRefill); //The amount of mana restored using potion
        }

        _regenTimer += Time.deltaTime;
        if (_regenTimer >= 1)
        {
            _manaSystem.Regen(mana2Regen);
            _regenTimer = 0;
        }

        manaBar.SetManaCurrent(_manaSystem.GetMana());
    }
    
    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }

}
