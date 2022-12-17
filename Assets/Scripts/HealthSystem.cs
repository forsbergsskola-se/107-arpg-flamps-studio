public class HealthSystem
{
    private int _healthCurrent;

    private int _healthMax;

    public HealthSystem(int healthMax)
    {
        _healthMax = healthMax;
        _healthCurrent = healthMax;
    }

    public int GetHealth()
    {
        return _healthCurrent;
    }

    public void Damage(int damageAmount)
    {
        _healthCurrent -= damageAmount;
        if (_healthCurrent < 0) _healthCurrent = 0;
    }

    public void Heal(int healAmount)
    {
        _healthCurrent += healAmount;
        if (_healthCurrent > _healthMax) _healthCurrent = _healthMax;
    }

    public void Regen(int regenAmount)
    {
        _healthCurrent += regenAmount;
        if (_healthCurrent > _healthMax) _healthCurrent = _healthMax;
    }
}