using UnityEngine;

public class GameEngine : MonoBehaviour
{
    private ManaSystem _manaSystem;
    private float _regenTimer;
    public int manaCost = 10;
    public int manaRefill = 10;
    [SerializeField] private int mana2Regen = 1;

    public ManaBar manaBar;

    private void Start()
    {
        _manaSystem = new ManaSystem(100);
        manaBar.SetManaMax(_manaSystem.GetMana());

        Debug.Log("Mana: " + _manaSystem.GetMana());
    }

    private void Update()
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
            _manaSystem.Regen(mana2Regen);
            _regenTimer = 0;
            Debug.Log("Regened: " + _manaSystem.GetMana());
        }

        manaBar.SetManaCurrent(_manaSystem.GetMana());
    }
}