using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healingbutton : MonoBehaviour
{
   public PlayerTestEngine healthRestored;
   public HealthSystem _healthSystem;
   public void Healing()
   {
    
      _healthSystem.Heal(30);
      
   }
}
