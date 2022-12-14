using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Spell
{
    private void Awake()
    {
        MyCollider = GetComponent<SphereCollider>();
        MyCollider.isTrigger = true;
        MyCollider.radius = spellToCast.spellRadius;

        MyRigidbody = GetComponent<Rigidbody>();
        // MyRigidbody.isKinematic = true;

        Destroy(gameObject, spellToCast.lifetime);
    }

    private void Update()
    {
        if (spellToCast.speed > 0) transform.Translate(Vector3.forward * (spellToCast.speed * Time.deltaTime));
    }

    private void OnTriggerStay (Collider other)
    {
        //Apply spell effects to whatever we hit.
        //Apply hit particle effects
        //Apply sound effects
    
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(spellToCast.damageAmount);
        }
    
        Destroy(gameObject, 5);
    }
}
