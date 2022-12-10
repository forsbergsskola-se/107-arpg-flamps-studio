using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpearScriptableObject", menuName = "ScriptableObjects/Spear")]
public class Spear : ScriptableObject
{
   public int damage = 20;
   public float attackcooldown = 0.5f;
}
