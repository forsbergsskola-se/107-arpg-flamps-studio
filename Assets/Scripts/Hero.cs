using System.Collections;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public enum WeaponType
    {
        Sword,
        Axe
    }

    public Sword sword;
    public Axe axe;
    //public Health HP;
    public EquippedWeapon equippedWeapon;
    public GameObject enemy;
    public WeaponType currentWeapon;
    public bool canAttack = true;
    private Animator _anim;
    private static readonly int Attack1 = Animator.StringToHash("Attack");

    public void Start()
    {
         _anim = GetComponent<Animator>();
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var distance = enemy.transform.position - transform.position;
            if (canAttack && distance.magnitude < 2.5f)
                Swing();
        }
    }

    private void Swing()
    {
        canAttack = false;
        
        _anim.SetTrigger(Attack1);
        //HP.health -= equippedweapon.damage;


        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(equippedWeapon.attackCooldown);

        canAttack = true;
    }
}