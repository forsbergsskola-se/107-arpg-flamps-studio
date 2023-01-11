using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    public GameObject Player;
    public GameObject myButton;
    public GameObject Healthorb;

    
    private void Update(){
    var distance = Player.transform.position - transform.position;

    if (Input.GetKeyDown(KeyCode.O) && distance.magnitude < 2.5f)
    {
        Healthorb.SetActive(false);
    }

    if (Healthorb.activeInHierarchy == false)
    {
       myButton.SetActive(true);

    }
    else if (Healthorb.activeInHierarchy == true)
    {
        myButton.SetActive(false);
        
    }
    }

    
}
