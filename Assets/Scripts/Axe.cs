using UnityEngine;

[CreateAssetMenu(fileName = "AxeScriptableObject", menuName = "ScriptableObjects/Axe")]
public class Axe : ScriptableObject
{
    public int damage = 40;
    public float attackCooldown = 1.5f;
}