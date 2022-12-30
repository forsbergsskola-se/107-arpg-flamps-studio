
using UnityEngine;

//attach to player
public class PlayerMagicSystem : MonoBehaviour
{
    //spellPrefabs here
    [SerializeField] private Spell[] spellToCast;

    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    [SerializeField] private float timeBetweenCast = 2f;

    [SerializeField] private Transform castPoint;

    private bool _castingMagic;
    private float _currentCastTimer;
    private float _currentManaRechageTimer;

    private void Awake()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        for (int i = 0; i < spellToCast.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                var hasEnoughMana = currentMana - spellToCast[i].spellToCast.manaCost >= 0f;
        
                if (!_castingMagic && hasEnoughMana)
                {
                    _castingMagic = true;
                    currentMana -= spellToCast[i].spellToCast.manaCost;
                    _currentCastTimer = 0;
                }
                _currentManaRechageTimer = 0;
                Instantiate(spellToCast[i], castPoint.position, castPoint.rotation);

            }

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
                    currentMana += manaRechargeRate * Time.deltaTime;
                    if (currentMana > maxMana) currentMana = maxMana;
                }
            }
        }
    }
}