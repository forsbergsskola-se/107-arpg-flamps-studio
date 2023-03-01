using System.Collections;
using Enemies;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hero : MonoBehaviour
{
    private static readonly int Attack1 = Animator.StringToHash("Attack");

    public EquippedWeapon equippedWeapon;
    public bool canAttack = true;
    public float attackRange = 2.5f;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) 
            return;
        
        if (!canAttack)
            return;

        foreach (var enemy in GameManager.enemies)
        {
            if (IsWithinAttackRange(enemy))
            {
                transform.LookAt(enemy.transform);
                Swing(enemy);
                break;
            }
        }
    }

    bool IsWithinAttackRange(Enemy enemy)
    {
        return Vector3.Distance(enemy.transform.position, transform.position) < attackRange;
    }

    private void Swing(Enemy enemyTarget) //plays the animation for attacking and activates attack cooldown.
    {
        _anim.SetTrigger(Attack1);
        enemyTarget.Hurt(equippedWeapon.damage);
        StartCoroutine(ActivateCoolDown());
    }

    private IEnumerator ActivateCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(equippedWeapon.attackCooldown);
        canAttack = true;
    }
}