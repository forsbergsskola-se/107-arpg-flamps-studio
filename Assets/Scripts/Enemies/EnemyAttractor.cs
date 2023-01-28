using UnityEngine;

namespace Enemies
{
    public class EnemyAttractor : MonoBehaviour
    {
        private SphereCollider _enemyTrigger;
        public float attractorRadius = 10;

        // Start is called before the first frame update
        void Start()
        {
            _enemyTrigger = gameObject.AddComponent<SphereCollider>();
            _enemyTrigger.isTrigger = true;
            _enemyTrigger.radius = attractorRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Enemy>() is { } enemyComponent)
            {
                enemyComponent.CurAttackTargetRef = gameObject;
            };
        }
    }
}
