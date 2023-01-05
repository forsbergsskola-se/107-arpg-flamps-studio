using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Hotbar : MonoBehaviour
{
    [SerializeField] private int maxMana = 100;
    [SerializeField] private int currentMana;
    [SerializeField] private int manaRechargeRate = 2;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    [SerializeField] private float timeBetweenCast = 2f;

    [SerializeField] private Transform castPoint;
    [SerializeField] private GameObject player;
    private Animator _anim;
    private static readonly int CastSpell1 = Animator.StringToHash("CastSpell");
    
    [SerializeField] private bool _castingMagic;
    private float _currentCastTimer;
    private float _currentManaRechageTimer;
    
    [SerializeField] private ManaBar manaBar;
    
    
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    private bool isCooldown = false;
    public KeyCode ability1;
    [SerializeField] private Spell spellToCast;
    
    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 10;
    private bool isCooldown2 = false;
    public KeyCode ability2;
    
    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 15;
    private bool isCooldown3 = false;
    public KeyCode ability3;
    
    [Header("Ability 4")]
    public Image abilityImage4;
    public float cooldown4 = 15;
    private bool isCooldown4 = false;
    public KeyCode ability4;
    
    [Header("Ability 5")]
    public Image abilityImage5;
    public float cooldown5 = 15;
    private bool isCooldown5 = false;
    public KeyCode ability5;
    [SerializeField] private Spell spellToCast5;
    
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        _anim = player.GetComponent<Animator>();
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;      
        abilityImage4.fillAmount = 0;
        abilityImage5.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (_castingMagic)
        {
            _currentCastTimer += Time.deltaTime;
            if (_currentCastTimer > timeBetweenCast) _castingMagic = false;
        }

        if (currentMana < maxMana && !_castingMagic)
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
        Ability1();
        Ability2();
        Ability3();      
        Ability4();
        Ability5();


    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            CastSpell();
        }

        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    
    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
    
    void Ability4()
    {
        if (Input.GetKey(ability4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
        }

        if (isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }

    void Ability5()
    {
        if (Input.GetKey(ability5) && isCooldown5 == false)
        {
            isCooldown5 = true;
            abilityImage5.fillAmount = 1;
            CastSpell5();
        }

        if (isCooldown5)
        {
            abilityImage5.fillAmount -= 1 / cooldown5 * Time.deltaTime;

            if (abilityImage5.fillAmount <= 0)
            {
                abilityImage5.fillAmount = 0;
                isCooldown5 = false;
            }
        }
    }

    
    private void CastSpell()
    {
        if (currentMana >= spellToCast.spellToCast.manaCost)
        {
            _castingMagic = true;
            _currentCastTimer = 0;
            _currentManaRechageTimer = 0;
            
            // Reduce the player's mana by the cost of the spell
            currentMana -= spellToCast.spellToCast.manaCost;
        
            // Update the mana bar
            manaBar.SetManaCurrent(currentMana);
        
            // Play the spell casting animation
            _anim.SetTrigger(CastSpell1);
            
            // Instantiate the spell prefab
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        }
    }
    private void CastSpell5()
    {
        if (currentMana >= spellToCast.spellToCast.manaCost)
        {
            _castingMagic = true;
            _currentCastTimer = 0;
            _currentManaRechageTimer = 0;
            
            // Reduce the player's mana by the cost of the spell
            currentMana -= spellToCast.spellToCast.manaCost;
        
            // Update the mana bar
            manaBar.SetManaCurrent(currentMana);
        
            // Play the spell casting animation
            _anim.SetTrigger(CastSpell1);
            
            // Instantiate the spell prefab
            Instantiate(spellToCast5, castPoint.position, castPoint.rotation);
        }
    }
}
