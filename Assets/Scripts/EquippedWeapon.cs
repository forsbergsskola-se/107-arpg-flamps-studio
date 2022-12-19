using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "EquippedWeaponScriptableObject", menuName = "ScriptableObjects/EquippedWeapon")]
public class EquippedWeapon : ScriptableObject
{
    public int damage = 100;
    public float attackcooldown = 1f;

    public void Start()
    {
        damage = 100;
        attackcooldown = 1f;
    }
}