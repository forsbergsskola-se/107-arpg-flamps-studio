using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    void Start()
    {
        ManaSystem manaSystem = new ManaSystem(100);
            
            Debug.Log("Mana: "+manaSystem.GetMana());
            manaSystem.manaUsed(10);
            Debug.Log("Mana: "+manaSystem.GetMana());
            manaSystem.manaRefill(8);
            Debug.Log("Mana: "+manaSystem.GetMana());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
