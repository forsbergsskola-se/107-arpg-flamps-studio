using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpecial : MonoBehaviour
{
    //public Health HP;
    public GameObject player;
    public EquippedWeapon equippedweapon;
    public GameObject SwordWeapon;
    public GameObject Weaponholder;


    private void OnTriggerEnter(Collider col)
    {
        var anim = player.GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Special"))
        {
           // HP.health -= equippedweapon.damage;
            Debug.Log("Hit");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && SwordWeapon.transform.IsChildOf(Weaponholder.transform))
        {
            var anim = player.GetComponent<Animator>();
            anim.SetTrigger("Special");
        }
    }
}