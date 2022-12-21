using UnityEngine;

public class WeaponAttach : MonoBehaviour
{
    public Sword sword;
    public Axe axe;
    public GameObject swordWeapon;
    public GameObject axeWeapon;
    public GameObject weaponHolder;
    public EquippedWeapon currentWeapon;

    
    //the point of this script is to give an equipped weapon stats (such as damage and speed) 
    //right now this is just an "idea" that needs the inventory system to work as intended
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) axeWeapon.transform.SetParent(weaponHolder.transform);

        if (swordWeapon.transform.IsChildOf(weaponHolder.transform))
        {
            currentWeapon.damage = sword.damage;
            currentWeapon.attackCooldown = sword.attackCooldown;
        }
        else if (axeWeapon.transform.IsChildOf(weaponHolder.transform))
        {
            currentWeapon.damage = axe.damage;
            currentWeapon.attackCooldown = axe.attackCooldown;
        }
    }
}