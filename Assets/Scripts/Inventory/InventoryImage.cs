using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryImage : MonoBehaviour, IPointerDownHandler
{
    public GameObject player;
    public GameObject item01Prefab;
    
    private PlayerTestEngine playerTestEngine;
    private HealthSystem _healthSystem;
    private InventorySystem inventorySystem;

    // Start is called before the first frame update
    void Start()
    {
        playerTestEngine = GameObject.FindObjectOfType<PlayerTestEngine>();
        inventorySystem = GameObject.FindObjectOfType<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Left Mouse Click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click");
            inventorySystem.RemoveItem("item01", 1);
            if (playerTestEngine != null)
            {
                HealthSystem healthSystem = playerTestEngine.GetHealthSystem();
                healthSystem.Damage(-20);
                playerTestEngine.healthbar.SetHealthCurrent(healthSystem.GetHealth());
            }
        }
        
        //Middle Mouse Click
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Middle click");
            inventorySystem.RemoveItem("item01", 1);
            
            //GameObject player = GameObject.Find("Player");
            //Vector3 playerPosition = player.transform.position;
            //Debug.Log("item01Prefab: " + item01Prefab);
            //Instantiate(item01Prefab, playerPosition, Quaternion.identity);

        }

        //Right Mouse Click
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click");

        }

    }
}

