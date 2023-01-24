using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryImage : MonoBehaviour, IPointerDownHandler
{
    public GameObject player;
    public List<string> itemName; // new variable to store the name of the linked item
    
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
            inventorySystem.RemoveItem(itemName, 1);
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
            List<string> items = new List<string>{"item01", "item02", "item03"};
            inventorySystem.RemoveItem(items, 1);
        }

        //Right Mouse Click
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click");

        }

    }
}

