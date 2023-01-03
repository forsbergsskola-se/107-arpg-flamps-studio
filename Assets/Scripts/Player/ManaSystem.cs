using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem
{
    private int _manaCurrent;
    private int _manaMax;

    public ManaSystem(int manaMax)
    {
        _manaMax = manaMax;
        _manaCurrent = manaMax;
    }

    public int GetMana()
    {
        return _manaCurrent;
    }

    public void manaUsed(int manaCost)
    {
        _manaCurrent -= manaCost;
        if (_manaCurrent < 0) _manaCurrent = 0;
    }

    public void manaRestore(int manaRefill)
    {
        _manaCurrent += manaRefill;
        if (_manaCurrent > _manaMax) _manaCurrent = _manaMax;
    }

    public void Regen(int regenAmount)
    {
        _manaCurrent += regenAmount;
        if (_manaCurrent > _manaMax) _manaCurrent = _manaMax;
    }
    
    public void IncreaseMaxMana(int manaAmount)
    {
        _manaMax += manaAmount;
    }
}