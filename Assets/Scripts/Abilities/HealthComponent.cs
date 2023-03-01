using UnityEngine;

//Attach this to enemy
namespace Abilities
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 50f;
        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damageToApply)
        {
            _currentHealth -= damageToApply;
            Debug.Log(_currentHealth);

            if (_currentHealth <= 0) Destroy(gameObject);
        }
    }
}