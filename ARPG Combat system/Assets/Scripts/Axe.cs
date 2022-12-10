using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AxeScriptableObject", menuName = "ScriptableObjects/Axe")]
public class Axe : ScriptableObject
{
   public int damage = 40;
   public float attackcooldown = 1.5f;
}
