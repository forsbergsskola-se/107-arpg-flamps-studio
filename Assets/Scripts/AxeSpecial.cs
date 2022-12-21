using UnityEngine;
public class AxeSpecial : MonoBehaviour
{
    // public Health HP;
    public GameObject player;
    public EquippedWeapon equippedWeapon;
    public GameObject axeWeapon;
    public GameObject weaponHolder;
    private static readonly int Special2 = Animator.StringToHash("Special2");
    private Animator _anim;
    

     void Start()
    {
        _anim = player.GetComponent<Animator>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && axeWeapon.transform.IsChildOf(weaponHolder.transform))
        {
            _anim.SetTrigger(Special2);
        }
    }


    private void OnTriggerEnter(Collider col)
    {

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Axe Special"))
            //HP.health -= equippedweapon.damage + 20;
            Debug.Log("Hit");
    }
}