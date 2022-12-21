using UnityEngine;

//attach to player
public class PlayerMagicSystem : MonoBehaviour
{
    //spellPrefabs here
    [SerializeField] private Spell spellToCast;

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
        var isSpellCastingHeldDown = Input.GetKeyDown(KeyCode.Alpha1);
        var hasEnoughMana = currentMana - spellToCast.spellToCast.manaCost >= 0f;

        if (!_castingMagic && isSpellCastingHeldDown && hasEnoughMana)
        {
            _castingMagic = true;
            currentMana -= spellToCast.spellToCast.manaCost;
            _currentCastTimer = 0;
            _currentManaRechageTimer = 0;
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
                currentMana += manaRechargeRate * Time.deltaTime;
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }
    }

    private void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
}