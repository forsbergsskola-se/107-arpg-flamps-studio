using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpecial : MonoBehaviour
{
  
    public Health HP;
    public GameObject player;
    public EquippedWeapon equippedweapon;
    public GameObject AxeWeapon;
    public GameObject Weaponholder;



    void OnTriggerEnter(Collider col)
    {
        Animator anim = player.GetComponent<Animator>();
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Axe Special"))
        {
            HP.health -= equippedweapon.damage + 20;
            Debug.Log("Hit");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && AxeWeapon.transform.IsChildOf(Weaponholder.transform))
        {
            
            Animator anim = player.GetComponent<Animator>();
            anim.SetTrigger("Special2");
        }
    }
}
        
    

