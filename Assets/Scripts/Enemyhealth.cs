using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
  public Health HP;

  public void Start()
  {
    HP.health = 100;
  }

  public void Update()
  {
    if (HP.health <= 0)
    {
      Destroy(gameObject);
    }
  }
}
