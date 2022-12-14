using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    ManaSystem manaSystem;
    float regenTimer = 0;
    void Start()
    {
        manaSystem = new ManaSystem(100);
            
            Debug.Log("Mana: "+manaSystem.GetMana());
            manaSystem.manaUsed(10);
            Debug.Log("Mana: "+manaSystem.GetMana());
            manaSystem.manaRefill(1);
            Debug.Log("Mana: "+manaSystem.GetMana());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            manaSystem.manaUsed(10);
            Debug.Log("Used: " + manaSystem.GetMana());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            manaSystem.manaRefill(10);
            Debug.Log("Refilled: " + manaSystem.GetMana());
        }
        regenTimer += Time.deltaTime;
        if (regenTimer >= 1)
        {
            manaSystem.Regen(5);
            regenTimer = 0;
            Debug.Log("Regened: " + manaSystem.GetMana());
        }
    }
}
