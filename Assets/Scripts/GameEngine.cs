using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    ManaSystem manaSystem;
    float regenTimer = 0;
    public int manaCost = 10;
    public int manaRefill = 10;
    private int manaRegen = 1;
    void Start()
    {
        manaSystem = new ManaSystem(100);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //cast spell, use mana
        {
            manaSystem.manaUsed(manaCost); //The mana used to cast a spell
            Debug.Log("Used: " + manaSystem.GetMana());
        }

        if (Input.GetKeyDown(KeyCode.H)) //use potion, refill mana
        {
            manaSystem.manaRestore(manaRefill); //The amount of mana restored using potion
            Debug.Log("Refilled: " + manaSystem.GetMana());
        }
        regenTimer += Time.deltaTime;
        if (regenTimer >= 1)
        {
            manaSystem.Regen(manaRegen);
            regenTimer = 0;
            Debug.Log("Regened: " + manaSystem.GetMana());
        }
    }
}
