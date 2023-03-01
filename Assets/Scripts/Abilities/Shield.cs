using UnityEngine;

namespace Abilities
{
    public class Shield: MonoBehaviour
    {
    
        [SerializeField] Transform player;
        // [SerializeField] private int damageAmount;
        // [SerializeField] private int lifeTime;
        public SpellSO shieldData;

        void Update()
        {
            transform.position = player.position + new Vector3(0,0.83f,0);
        }

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
                enemyHealth.TakeDamage(shieldData.damageAmount);
            }

        }
    }
}