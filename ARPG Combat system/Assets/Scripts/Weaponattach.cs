using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponattach : MonoBehaviour
{
    public Sword sword;
    public Axe axe;
    public Spear spear;
    public GameObject Swordweapon;
    public GameObject Axeweapon;
    public GameObject Spearweapon;
    public GameObject Weaponholder;
    public EquippedWeapon currentweapon;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Axeweapon.transform.SetParent(Weaponholder.transform);
            
            
        }
        
        if (Swordweapon.transform.IsChildOf(Weaponholder.transform))
            {
               currentweapon.damage = sword.damage;
                currentweapon.attackcooldown = sword.attackcooldown;
            }
            else if (Axeweapon.transform.IsChildOf(Weaponholder.transform))
            {
                currentweapon.damage = axe.damage;
                currentweapon.attackcooldown = axe.attackcooldown;
            }
            else if (Spearweapon.transform.IsChildOf(Weaponholder.transform))
            {
                currentweapon.damage = spear.damage;
                currentweapon.attackcooldown = spear.attackcooldown;
            }
    }

       
    
}
