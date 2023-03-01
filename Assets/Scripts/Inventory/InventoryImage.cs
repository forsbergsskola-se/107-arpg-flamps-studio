using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventoryImage : MonoBehaviour, IPointerDownHandler
    {
        public GameObject player;
        public List<string> itemName; // new variable to store the name of the linked item
    
        private PlayerTestEngine playerTestEngine;
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
                List<string> items = new List<string>{"item01", "item02", "item03"};
                inventorySystem.RemoveItem(itemName, 1);
            }
        
            //Middle Mouse Click
            else if (eventData.button == PointerEventData.InputButton.Middle)
            {
                Debug.Log("Middle click removes item from inventory");
                List<string> items = new List<string>{"item01", "item02", "item03"};
                inventorySystem.RemoveItem(items, 1);
            }

            //Right Mouse Click
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Right click Does Nothing");

            }
        }
    }
}

