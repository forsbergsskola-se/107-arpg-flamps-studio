using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Hotbar : MonoBehaviour
{
    [SerializeField] private int charLevel = 1;
    [SerializeField] private int maxMana = 100;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2;
    
    [SerializeField] private Transform selfCastPoint;
    [SerializeField] private Transform castPoint;
    [SerializeField] private GameObject player;

    private Animator _anim;
    private static readonly int CastSpell1 = Animator.StringToHash("CastSpell");

    [SerializeField] private Slider slider;
    [SerializeField] private Text currentManaText;
    [SerializeField] private Text maxManaText;
    [SerializeField] private Text charLevelText;

    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    private bool isCooldown = false;
    public KeyCode ability1;
    [SerializeField] private Spell spellToCast;
    public AudioSource spell1Fx;
    
    [Header("Ability 2")]
    public Image abilityImage2;
    public int manaCost2; 
    private bool isCooldown2 = false;
    public float cooldown2 = 10;
    public KeyCode ability2;
    [SerializeField] private float shieldActiveTime;
    [SerializeField] private GameObject spellToCast2;
    public AudioSource spell2Fx;


    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 15;
    private bool isCooldown3 = false;
    public KeyCode ability3;
    [SerializeField] private float instantMana;
    public AudioSource spell3Fx;

    
    [Header("Ability 4")]
    public Image abilityImage4;
    public float cooldown4 = 15;
    private bool isCooldown4 = false;
    public KeyCode ability4;
    [SerializeField] private Spell spellToCast4;
    public AudioSource spell4Fx;


    [Header("Ability 5")]
    public Image abilityImage5;
    public float cooldown5 = 5;
    private bool isCooldown5 = false;
    public KeyCode ability5;
    [SerializeField] private float manaCost5;
    public AudioSource spell5Fx;


    public float dashDistance = 5f;
    public float dashSpeed = 1f;
    public float dashDelay = 1f;
    private bool dashing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        slider.maxValue = maxMana;
        slider.value = currentMana;
        currentManaText.text = maxMana.ToString();
        maxManaText.text = maxMana.ToString();
        charLevelText.text = charLevel.ToString();

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
        SpellManaSystem();
        Abilities();
    }

    void SpellManaSystem()
    {
        // Update the mana bar
        maxManaText.text = maxMana.ToString();
        slider.value = currentMana;
        currentManaText.text = Convert.ToInt32(currentMana).ToString();
        if (currentMana < maxMana)
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            if (currentMana > maxMana) currentMana = maxMana;
        }
    }

    void Abilities()
    {
        Ability1();
        Ability2();
        Ability3();      
        Ability4();
        Ability5();
    }
    
    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false && currentMana >= spellToCast.spellToCast.manaCost )
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
        if (Input.GetKey(ability2) && isCooldown2 == false && currentMana >= manaCost2)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
            spellToCast2.SetActive(true);
            // Reduce the player's mana by the cost of the spell
            currentMana -= manaCost2;
        }
        
        if (isCooldown2)
        {
            shieldActiveTime -= 1 * Time.deltaTime;
            if (shieldActiveTime<=0)
            {
                spellToCast2.SetActive(false);
                shieldActiveTime = 0;

            }
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
                shieldActiveTime = 5;
            }
        }
    }
    
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
            currentMana += instantMana;
            if (currentMana > maxMana) currentMana = maxMana;
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
       
        if (Input.GetKey(ability4) && isCooldown4 == false && currentMana >= spellToCast4.spellToCast.manaCost)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
            CastSpell4();
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
        if (Input.GetKey(ability5) && isCooldown5 == false && !dashing && currentMana >= manaCost2)
        {
            currentMana -= manaCost5;
            isCooldown5 = true;
            abilityImage5.fillAmount = 1;
            
            dashing = true;
            StartCoroutine(PerformDash());
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

            // Reduce the player's mana by the cost of the spell
            currentMana -= spellToCast.spellToCast.manaCost;
            
            // Play the spell casting animation
            _anim.SetTrigger(CastSpell1);
            
            // Instantiate the spell prefab
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
    
    private void CastSpell4()
    {
        // Reduce the player's mana by the cost of the spell
        currentMana -= spellToCast4.spellToCast.manaCost;
            
        // Play the spell casting animation
        _anim.SetTrigger(CastSpell1);
            
        // Instantiate the spell prefab
        Instantiate(spellToCast4, castPoint.position, castPoint.rotation);
    }
   
    
    IEnumerator PerformDash()
    {
        Vector3 startPos = player.transform.position;
        Vector3 endPos = startPos + player.transform.forward * dashDistance;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * dashSpeed;
           player.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
        dashing = false;
        yield return new WaitForSeconds(dashDelay);
    }
}
