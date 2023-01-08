using UnityEngine;

//attach to spellPrefabs
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellSO spellToCast;

    protected SphereCollider MyCollider;
    protected Rigidbody MyRigidbody;

    private void Awake()
    {
        MyCollider = GetComponent<SphereCollider>();
        MyCollider.isTrigger = true;
        MyCollider.radius = spellToCast.spellRadius;

        MyRigidbody = GetComponent<Rigidbody>();
        MyRigidbody.isKinematic = true;

        Destroy(gameObject, spellToCast.lifetime);
    }

    private void Update()
    {
        if (spellToCast.speed > 0) transform.Translate(Vector3.forward * (spellToCast.speed * Time.deltaTime));
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
            enemyHealth.TakeDamage(spellToCast.damageAmount);
        }

        Destroy(gameObject);
    }
}