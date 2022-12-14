public class ManaSystem
{
    private int _manaCurrent;
    private int _manaMax;

    public ManaSystem(int manaMax)
    {
        this._manaMax = manaMax;
        _manaCurrent = manaMax;
    }

    public int GetMana()
    {
        return _manaCurrent;
    }

    public void manaUsed(int manaCost)
    {
        _manaCurrent -= manaCost;
    }

    public void manaRefill(int manaTopUp)
    {
        _manaCurrent += manaTopUp;
    }
    
    public void Regen(int regenAmount)
    {
        _manaCurrent += regenAmount;
        if (_manaCurrent > _manaMax) _manaCurrent = _manaMax;
    }
}
