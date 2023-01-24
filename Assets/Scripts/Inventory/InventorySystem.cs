using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    public InventoryUI inventoryUI; 

    private void Start()
    {
        // Initialize the inventory with empty values
        inventory.Add("item01", 0);
        Debug.Log("item01");
        inventory.Add("item02", 0);
        Debug.Log("item02");
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
    
    public void RemoveItem(string itemName, int amount)
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
            inventoryUI.UpdateInventoryUI();
        }
        else
        {
            Debug.Log("Item not found in inventory: " + itemName);
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