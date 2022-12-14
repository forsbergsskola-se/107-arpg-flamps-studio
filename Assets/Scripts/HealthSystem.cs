using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int healthCurrent;

    private int healthMax;

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        healthCurrent = healthMax;
    }

    public int GetHealth()
    {
        return healthCurrent;
    }

    public void Damage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        if (healthCurrent < 0) healthCurrent = 0;
    }

    public void Heal(int healAmount)
    {
        healthCurrent += healAmount;
        if (healthCurrent > healthMax) healthCurrent = healthMax;
    }
}
