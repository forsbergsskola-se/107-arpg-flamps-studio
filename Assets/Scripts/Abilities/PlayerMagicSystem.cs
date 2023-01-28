using System;
using UnityEngine;
using UnityEngine.UIElements;

//attach to player
public class PlayerMagicSystem : MonoBehaviour
{
    //spellPrefabs here
    [SerializeField] private Spell spellToCast;

    [SerializeField] private int maxMana = 100;
    [SerializeField] private int currentMana;
    [SerializeField] private int manaRechargeRate = 2;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    [SerializeField] private float timeBetweenCast = 2f;

    [SerializeField] private Transform castPoint;
    private Animator _anim;
    private static readonly int CastSpell1 = Animator.StringToHash("CastSpell");
    
    [SerializeField] private bool _castingMagic;
    private float _currentCastTimer;
    private float _currentManaRechageTimer;
    
    [SerializeField] private ManaBar manaBar;

    private void Awake()
    {
        currentMana = maxMana;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        var isSpellCastingHeldDown = Input.GetKeyDown(KeyCode.Alpha1);
        var hasEnoughMana = currentMana - spellToCast.spellToCast.manaCost >= 0f;

        if (!_castingMagic && isSpellCastingHeldDown && hasEnoughMana)
        {
            CastSpell();
        }

        if (_castingMagic)
        {
            _currentCastTimer += Time.deltaTime;
            if (_currentCastTimer > timeBetweenCast) _castingMagic = false;
        }

        if (currentMana < maxMana && !_castingMagic && !isSpellCastingHeldDown)
        {
            _currentManaRechageTimer += Time.deltaTime;

            if (_currentManaRechageTimer > timeToWaitForRecharge)
            {
                currentMana += Convert.ToInt32(manaRechargeRate * Time.deltaTime);
                if (currentMana > maxMana) currentMana = maxMana;

                // Update the mana bar
                manaBar.SetManaCurrent(currentMana);
            }
        }
    }

    private void CastSpell()
    {
        // _anim.SetTrigger(CastSpell1);
        // Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        
        if (currentMana >= spellToCast.spellToCast.manaCost)
        {
            _castingMagic = true;
            _currentCastTimer = 0;
            _currentManaRechageTimer = 0;
            
            // Reduce the player's mana by the cost of the spell
            currentMana -= spellToCast.spellToCast.manaCost;

            // Update the mana bar
            // manaBar.SetManaCurrent(currentMana);

            // Play the spell casting animation
            _anim.SetTrigger(CastSpell1);
            
            // Instantiate the spell prefab
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
            
        }
    }
}