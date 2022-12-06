using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Health HP;
    public GameObject player;
    public GameObject enemy;
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;


    public void Update()
    {
        Vector3 Distance = enemy.transform.position - player.transform.position;
        if (Input.GetMouseButtonDown(0))
            if (CanAttack &&  Distance.magnitude < 2.5f)
            {
                attack();
            }
    }

    private void attack()
    {
            CanAttack = false;
            HP.health -= 50;
            Debug.Log(HP.health);
            StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
    }
}