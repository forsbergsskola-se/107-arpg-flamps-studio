using UnityEngine;

namespace Abilities
{
    public class SpellTakeDamage : MonoBehaviour
    {
        [SerializeField] private int damageAmount;
        private void OnTriggerEnter(Collider other)
        {
            //Apply spell effects to whatever we hit.
            //Apply hit particle effects
            //Apply sound effects
        
            if (other.gameObject.CompareTag("Player"))
            {
                return;
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                var enemyHealth = other.GetComponent<HealthComponent>();
                enemyHealth.TakeDamage(damageAmount);
            }

            Destroy(gameObject);
        }
    }
}
