using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Sword sword;
    public Axe axe;
    public Spear spear;
    public Health HP;
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
        Sword, Axe, Spear,
    }

    public void Update()
    {
      /*  if (!Swordweapon.activeInHierarchy && !Axeweapon.activeInHierarchy)
        {
            CurrentWeapon = WeaponType.Spear;
        }
        else if (!Swordweapon.activeInHierarchy && !Spearweapon.activeInHierarchy)
        {
            CurrentWeapon = WeaponType.Axe;
        }
        else if (!Axeweapon.activeInHierarchy && !Spearweapon.activeInHierarchy)
        {
            CurrentWeapon = WeaponType.Sword;
       */ 
        
        Vector3 Distance = enemy.transform.position - player.transform.position;
        if (Input.GetMouseButtonDown(0))
            if (CanAttack &&  Distance.magnitude < 2.5f)
            {
                attack();
            }
    }

    private void attack()
    {
            CanAttack = false;
            Animator anim = player.GetComponent<Animator>();
            anim.SetTrigger("Attack");
            HP.health -= equippedweapon.damage;
           /* if (CurrentWeapon == WeaponType.Sword)
            {
                HP.health -= sword.damage;
            }
            else if(CurrentWeapon == WeaponType.Axe)
            {
                HP.health -= axe.damage;
            }
            else if (CurrentWeapon == WeaponType.Spear)
            {
                HP.health -= spear.damage;
            }*/

           
            StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        if (CurrentWeapon == WeaponType.Sword)
        {
            yield return new WaitForSeconds(sword.attackcooldown);
        }
        if (CurrentWeapon == WeaponType.Axe)
        {
            yield return new WaitForSeconds(axe.attackcooldown);
        }
        if (CurrentWeapon == WeaponType.Spear)
        {
            yield return new WaitForSeconds(spear.attackcooldown);
        }

        CanAttack = true;
    }
}