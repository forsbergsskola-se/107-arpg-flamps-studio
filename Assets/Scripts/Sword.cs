using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordScriptableObject", menuName = "ScriptableObjects/Sword")]
public class Sword : ScriptableObject
{
    public int damage = 20;
    public float attackcooldown = 1f;
}