using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        private Dictionary<string, int> inventory = new Dictionary<string, int>();
        public InventoryUI inventoryUI;

        private PlayerHPandXP _playerBars;
    
        private void Start()
        {
            _playerBars = GetComponent<PlayerHPandXP>();
        
            // Initialize the inventory with empty values
            inventory.Add("item01", 0);
            inventory.Add("item02", 0);
            inventory.Add("item03", 0);
            inventory.Add("item04", 0);
            inventory.Add("item05", 0);
        }

        public void AddItem(string itemName)
        {
            if (inventory.ContainsKey(itemName))
            {
                int currentCount = inventory[itemName];
                inventory[itemName]++;
                Debug.Log(itemName + " picked up! " + currentCount + " -> " + inventory[itemName]);
                inventoryUI.UpdateInventoryUI(); // add this line
            }
            else
            {
                Debug.Log("Item not found in inventory: " + itemName);
            }
        }
    
        public void RemoveItem(List<string> itemNames, int amount)
        {
            foreach (string itemName in itemNames)
            {
                if (inventory.ContainsKey(itemName))
                {
                    int currentCount = inventory[itemName];
                    if (currentCount <= 0) 
                    {
                        return;
                    }
                    inventory[itemName] -= amount;
                    Debug.Log(itemName + " removed! " + currentCount + " -> " + inventory[itemName]);

                    if (itemName == "item01") // health consumable
                    {
                        _playerBars.HealthCur += 25;
                    }
                
                    inventoryUI.UpdateInventoryUI();
                }
                else
                {
                    Debug.Log("Item not found in inventory: " + itemName);
                }
            }
        }

        public int GetItemCount(string itemName)
        {
            if (inventory.ContainsKey(itemName))
            {
                return inventory[itemName];
            }
            else
            {
                Debug.Log("Item not found in inventory: " + itemName);
                return 0;
            }
        }
    }
}