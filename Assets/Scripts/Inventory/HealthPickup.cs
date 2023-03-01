using UnityEngine;

namespace Inventory
{
    public class HealthPickup : MonoBehaviour
    {
        public float pickupDistance = 1f;
        public GameObject player;

        void Update()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if(distance <= pickupDistance)
            {
                player.GetComponent<InventorySystem>().AddItem("item01");
                Destroy(gameObject);
            }
        }
    }
}
