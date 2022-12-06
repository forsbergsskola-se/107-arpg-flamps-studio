using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthScriptableObject", menuName = "ScriptableObjects/Health")]
public class Health : ScriptableObject
{
    public int health = 100;
} 