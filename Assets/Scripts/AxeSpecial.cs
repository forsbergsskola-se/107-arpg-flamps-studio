using System;
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

    public void Start()
    {
        _anim = player.GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && axeWeapon.transform.IsChildOf(weaponHolder.transform))
        {
             _anim = player.GetComponent<Animator>();
            _anim.SetTrigger(Special2);
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        var anim = player.GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Axe Special"))
            //HP.health -= equippedweapon.damage + 20;
            Debug.Log("Hit");
    }
}