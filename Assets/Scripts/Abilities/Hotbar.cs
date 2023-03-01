using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    [RequireComponent(typeof(Animator))]
    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private int charLevel = 1;
        [SerializeField] private int maxMana = 100;
        [SerializeField] private float currentMana;
        [SerializeField] private float manaRechargeRate = 2;
    
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
        private bool _isCooldown;
        public KeyCode ability1;
        [SerializeField] private Spell spellToCast;
        public AudioSource spell1Fx;
    
        [Header("Ability 2")]
        public Image abilityImage2;
        public int manaCost2; 
        private bool _isCooldown2;
        public float cooldown2 = 10;
        public KeyCode ability2;
        [SerializeField] private float shieldActiveTime;
        [SerializeField] private GameObject spellToCast2;
        public AudioSource spell2Fx;


        [Header("Ability 3")]
        public Image abilityImage3;
        public float cooldown3 = 15;
        private bool _isCooldown3;
        public KeyCode ability3;
        [SerializeField] private float instantMana;
        public AudioSource spell3Fx;

    
        [Header("Ability 4")]
        public Image abilityImage4;
        public float cooldown4 = 15;
        private bool _isCooldown4;
        public KeyCode ability4;
        [SerializeField] private Spell spellToCast4;
        public AudioSource spell4Fx;


        [Header("Ability 5")]
        public Image abilityImage5;
        public float cooldown5 = 5;
        private bool _isCooldown5;
        public KeyCode ability5;
        [SerializeField] private float manaCost5;
        public AudioSource spell5Fx;


        public float dashDistance = 5f;
        public float dashSpeed = 1f;
        public float dashDelay = 1f;
        private bool _dashing;
    
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
            if (Input.GetKey(ability1) && _isCooldown == false && currentMana >= spellToCast.spellToCast.manaCost )
            {
                _isCooldown = true;
                abilityImage1.fillAmount = 1;
                CastSpell();
            }

            if (_isCooldown)
            {
                abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

                if (abilityImage1.fillAmount <= 0)
                {
                    abilityImage1.fillAmount = 0;
                    _isCooldown = false;
                }
            }
        }
    
        void Ability2()
        {
            if (Input.GetKey(ability2) && _isCooldown2 == false && currentMana >= manaCost2)
            {
                _isCooldown2 = true;
                abilityImage2.fillAmount = 1;
                spellToCast2.SetActive(true);
                // Reduce the player's mana by the cost of the spell
                currentMana -= manaCost2;
            }
        
            if (_isCooldown2)
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
                    _isCooldown2 = false;
                    shieldActiveTime = 5;
                }
            }
        }
    
        void Ability3()
        {
            if (Input.GetKey(ability3) && _isCooldown3 == false)
            {
                _isCooldown3 = true;
                abilityImage3.fillAmount = 1;
                currentMana += instantMana;
                if (currentMana > maxMana) currentMana = maxMana;
            }

            if (_isCooldown3)
            {
                abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

                if (abilityImage3.fillAmount <= 0)
                {
                    abilityImage3.fillAmount = 0;
                    _isCooldown3 = false;
                }
            }
        }
    
        void Ability4()
        {
       
            if (Input.GetKey(ability4) && _isCooldown4 == false && currentMana >= spellToCast4.spellToCast.manaCost)
            {
                _isCooldown4 = true;
                abilityImage4.fillAmount = 1;
                CastSpell4();
            }

            if (_isCooldown4)
            {
                abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

                if (abilityImage4.fillAmount <= 0)
                {
                    abilityImage4.fillAmount = 0;
                    _isCooldown4 = false;
                }
            }
        }

        void Ability5()
        {
            if (Input.GetKey(ability5) && _isCooldown5 == false && !_dashing && currentMana >= manaCost2)
            {
                currentMana -= manaCost5;
                _isCooldown5 = true;
                abilityImage5.fillAmount = 1;
            
                _dashing = true;
                StartCoroutine(PerformDash());
            }

            if (_isCooldown5)
            {
                abilityImage5.fillAmount -= 1 / cooldown5 * Time.deltaTime;

                if (abilityImage5.fillAmount <= 0)
                {
                    abilityImage5.fillAmount = 0;
                    _isCooldown5 = false;
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
            _dashing = false;
            yield return new WaitForSeconds(dashDelay);
        }
    }
}
