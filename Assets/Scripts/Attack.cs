using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
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
    public GameObject player;
    public GameObject enemy;
    public WeaponType currentWeapon;
    public bool canAttack = true;
    private static readonly int Attack1 = Animator.StringToHash("Attack");

    public void Update()
    {
        var distance = enemy.transform.position - player.transform.position;
        if (Input.GetMouseButtonDown(0))
            if (canAttack && distance.magnitude < 2.5f)
                Swing();
    }

    private void Swing()
    {
        canAttack = false;
        var anim = player.GetComponent<Animator>();
        anim.SetTrigger(Attack1);
        //HP.health -= equippedweapon.damage;


        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(equippedWeapon.attackCooldown);

        canAttack = true;
    }
}