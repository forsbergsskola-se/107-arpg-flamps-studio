using UnityEngine;

public class WeaponAttach : MonoBehaviour
{
    public GameObject Player;
    public Sword sword;
    //public Axe axe;
    public GameObject swordWeapon; //the sword prefab (your choice)
    //public GameObject axeWeapon; // the axe prefab (your choice)
    public GameObject weaponHolder; //empty object attached to player arm
    public EquippedWeapon currentWeapon;


    //the point of this script is to give an equipped weapon stats (such as damage and speed) 
    //right now this is just an "idea" that needs the inventory system to work as intended

    private void Update()
    {
        var distance = Player.transform.position - transform.position;
        if (Input.GetKeyDown(KeyCode.O) && distance.magnitude < 2.5f)
        {
            swordWeapon.transform.SetParent(weaponHolder.transform); //attaches weapon of choice to weaponHolder.
        }
        //(using axe for testing purposes only)

        //code below changes equipped weapon scriptable object to match weapon type.
        if (swordWeapon.transform.IsChildOf(weaponHolder.transform))
        {
            currentWeapon.damage = sword.damage;
            currentWeapon.attackCooldown = sword.attackCooldown;
        }
        /*else if (axeWeapon.transform.IsChildOf(weaponHolder.transform))
        {
            currentWeapon.damage = axe.damage;
            currentWeapon.attackCooldown = axe.attackCooldown;
        }*/
    }
}