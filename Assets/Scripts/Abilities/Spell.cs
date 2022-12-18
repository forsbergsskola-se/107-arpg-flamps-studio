using UnityEngine;
//attach to spellPrefabs
[RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellSO spellToCast;

    private SphereCollider _myCollider;
    private Rigidbody _myRigidbody;

    private void Awake()
    {
        _myCollider = GetComponent<SphereCollider>();
        _myCollider.isTrigger = true;
        _myCollider.radius = spellToCast.spellRadius;

        _myRigidbody = GetComponent<Rigidbody>();
        _myRigidbody.isKinematic = true;
        
        Destroy(this.gameObject, spellToCast.lifetime);
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(spellToCast.damageAmount);
        }
        
        Destroy(this.gameObject);
    }
}
