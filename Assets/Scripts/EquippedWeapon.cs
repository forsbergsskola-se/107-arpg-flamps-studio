using UnityEngine;

[CreateAssetMenu(fileName = "EquippedWeaponScriptableObject", menuName = "ScriptableObjects/EquippedWeapon")]
public class EquippedWeapon : ScriptableObject
{
    public int damage = 100;
    public float attackCooldown = 1f;

    
}