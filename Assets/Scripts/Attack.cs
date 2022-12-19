using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Sword sword;
    public Axe axe;
    //public Health HP;
    public EquippedWeapon equippedweapon;
    public GameObject Swordweapon;
    public GameObject Axeweapon;
    public GameObject Spearweapon;
    public GameObject player;
    public GameObject enemy;
    public WeaponType CurrentWeapon;
    public bool CanAttack = true;


    public enum WeaponType
    {
        Sword,
        Axe,
        Spear
    }

    public void Update()
    {
        var Distance = enemy.transform.position - player.transform.position;
        if (Input.GetMouseButtonDown(0))
            if (CanAttack && Distance.magnitude < 2.5f)
                attack();
    }

    private void attack()
    {
        CanAttack = false;
        var anim = player.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        //HP.health -= equippedweapon.damage;


        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(equippedweapon.attackcooldown);

        CanAttack = true;
    }
}