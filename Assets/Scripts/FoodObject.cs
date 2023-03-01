using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "InventoryData System/Items/Food")]
public class FoodObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Food;
    }
}
