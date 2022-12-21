using UnityEngine;

public class SwordSpecial : MonoBehaviour
{
    //public Health HP;
    public GameObject player;
    public EquippedWeapon equippedWeapon;
    public GameObject swordWeapon;
    public GameObject weaponHolder;
    private static readonly int Special = Animator.StringToHash("Special");
    private Animator _anim;

     void Start()
    {
        _anim = player.GetComponent<Animator>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && swordWeapon.transform.IsChildOf(weaponHolder.transform))
        {
             
            _anim.SetTrigger(Special);
        }
    }


    private void OnTriggerEnter(Collider col)
    {

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Special"))
            // HP.health -= equippedweapon.damage;
            Debug.Log("Hit");
    }
}