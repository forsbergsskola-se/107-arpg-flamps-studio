using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlast : Spell
{

    private void Awake()
    {
        MyCollider = GetComponent<SphereCollider>();
        MyCollider.isTrigger = true;
        MyCollider.radius = spellToCast.spellRadius;

        MyRigidbody = GetComponent<Rigidbody>();
        MyRigidbody.isKinematic = true;
        
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
        
    }
}
