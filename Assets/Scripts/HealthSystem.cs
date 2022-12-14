public class HealthSystem
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
    
    public void Regen(int regenAmount)
    {
        healthCurrent += regenAmount;
        if (healthCurrent > healthMax) healthCurrent = healthMax;
    }
}
