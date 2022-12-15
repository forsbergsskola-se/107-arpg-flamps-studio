using UnityEngine;

public class GameEngine : MonoBehaviour
{
    ManaSystem _manaSystem;
    float _regenTimer;
    public int manaCost = 10;
    public int manaRefill = 10;
    [SerializeField] private int manaRegen = 1;

    public ManaBar manaBar;
    void Start()
    {
        this._manaSystem = new ManaSystem(100);
        manaBar.SetManaMax(_manaSystem.GetMana());
        
        Debug.Log(("Mana: " + _manaSystem.GetMana()));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //cast spell, use mana
        {
            _manaSystem.manaUsed(manaCost); //The mana used to cast a spell
            Debug.Log("Used: " + _manaSystem.GetMana());
        }

        if (Input.GetKeyDown(KeyCode.H)) //use potion, refill mana
        {
            _manaSystem.manaRestore(manaRefill); //The amount of mana restored using potion
            Debug.Log("Refilled: " + _manaSystem.GetMana());
        }
        _regenTimer += Time.deltaTime;
        if (_regenTimer >= 1)
        {
            _manaSystem.Regen(manaRegen);
            _regenTimer = 0;
            Debug.Log("Regened: " + _manaSystem.GetMana());
        }
    }
}
