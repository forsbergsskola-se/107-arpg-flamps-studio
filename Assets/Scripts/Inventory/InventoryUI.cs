using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public InventorySystem inventorySystem;
        public Image[] itemImages;
        public TextMeshProUGUI[] itemCountTexts;
        private string[] itemNames = {"item01", "item02", "item03", "item04", "item05"};

        private void Start()
        {
            if(inventorySystem == null || itemImages.Any(i => i == null) || itemCountTexts.Any(i => i == null))
            {
                return;
            }
            UpdateInventoryUI();
        }

        public void UpdateInventoryUI()
        {
            for(int i = 0; i < itemNames.Length; i++)
            {
                int itemCount = inventorySystem.GetItemCount(itemNames[i]);
                itemCountTexts[i].text = itemCount.ToString();
                if(itemCount == 0)
                {
                    itemImages[i].enabled = false;
                    itemCountTexts[i].enabled = false;
                }
                else
                {
                    itemImages[i].enabled = true;
                    itemCountTexts[i].enabled = true;
                }
            }
        }
    }
}