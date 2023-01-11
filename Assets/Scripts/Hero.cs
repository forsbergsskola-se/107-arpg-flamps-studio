using System.Collections;
using Enemies;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public enum WeaponType
    {
        Sword,
        Axe
    }

    private static readonly int Attack1 = Animator.StringToHash("Attack");

    // all of these are needed
    public Sword sword;

    public Axe axe;

    //public Health HP;
    public EquippedWeapon equippedWeapon;

    //public GameObject enemy;
    public bool canAttack = true;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemyGameObject in enemies)
        {
            var enemy = enemyGameObject.GetComponent<Enemy>();

            //checks if player is close enough to allow attacking and attacks if yes.
            if (Input.GetMouseButtonDown(
                    0)) //condition will have to be changed to match the player movement from stewart.
            {
                var distance = enemy.transform.position - transform.position;
                if (canAttack && distance.magnitude < 2.5f)
                {
                    transform.LookAt(enemy.transform);
                    Swing(enemy);
                }
            }
        }
    }

    private void Swing(Enemy enemyTarget) //plays the animation for attacking and activates attack cooldown.
    {
        canAttack = false;

        _anim.SetTrigger(Attack1);
        enemyTarget.healthCur -= equippedWeapon.damage;

        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(equippedWeapon.attackCooldown);

        canAttack = true;
    }
}