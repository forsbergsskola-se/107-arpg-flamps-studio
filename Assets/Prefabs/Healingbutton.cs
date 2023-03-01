using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Healingbutton : MonoBehaviour
{
   public PlayerTestEngine healthRestored;
   public HealthSystem _healthSystem;
   public GameObject button;
   public void Healing()
   {
      _healthSystem.Heal(30);
      button.SetActive(false);
   }
}
