using UnityEngine;

public class SwordSpecial : MonoBehaviour
{
    private static readonly int Special = Animator.StringToHash("Special");

    //all needed
    //public Health HP;
    public GameObject player;
    public EquippedWeapon equippedWeapon;
    public GameObject swordWeapon;
    public GameObject weaponHolder;
    private Animator _anim;

    private void Start()
    {
        _anim = player.GetComponent<Animator>();
    }

    private void Update() //lets you use special weapon ability by pressing 1, as long as its child of weaponHolder.
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && swordWeapon.transform.IsChildOf(weaponHolder.transform))
            _anim.SetTrigger(Special);
    }


    private void OnTriggerEnter(Collider col) // makes the collider deal damage as long as the animation is still playing.
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Special"))
            // HP.health -= equippedweapon.damage;
            Debug.Log("Hit");
    }
}