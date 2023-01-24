using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    public float pickupDistance = 1f;
    public GameObject player;

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= pickupDistance)
        {
            Debug.Log("Player touches item");
            player.GetComponent<InventorySystem>().AddItem("item02");
            Destroy(gameObject);
        }
    }
}