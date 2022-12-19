using UnityEngine;

public class SwordSpecial : MonoBehaviour
{
    //public Health HP;
    public GameObject player;
    public EquippedWeapon equippedWeapon;
    public GameObject swordWeapon;
    public GameObject weaponHolder;
    private static readonly int Special = Animator.StringToHash("Special");

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && swordWeapon.transform.IsChildOf(weaponHolder.transform))
        {
            var anim = player.GetComponent<Animator>();
            anim.SetTrigger(Special);
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        var anim = player.GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Special"))
            // HP.health -= equippedweapon.damage;
            Debug.Log("Hit");
    }
}