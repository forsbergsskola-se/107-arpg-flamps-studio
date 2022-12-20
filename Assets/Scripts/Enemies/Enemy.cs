using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(Collider))]
public class Enemy : NPC /*, IHealth */
{
    
    public float damage = 7;
    public float maxHealth = 100;
    
    
    protected float CurHealth;

    protected Rigidbody RigBod;

    // Debugging
    private Dictionary<string, Action> _dbgBtnsDict;
    
    // Animation
    protected Animator Anim;
    private static readonly int CurVelocity = Animator.StringToHash("curVelocity");
    
    


    private void Awake()
    {
        // NPC Values
        CurHealth = maxHealth;
        
        // Components
        Anim = GetComponent<Animator>();
        RigBod = GetComponent<Rigidbody>();
        

    }
    
    // Start is called before the first frame update
    void Start()
    { 
        // Debug
        _dbgBtnsDict = new Dictionary<string, Action>
        {
            { "Damage by 5", delegate
                {
                    Hurt(5);
                    Debug.Log($"Ouch Pain, {nameof(CurHealth)} = {CurHealth}");
                }
            },           
            { "Kill", delegate
                {
                    Die();
                    Debug.Log($"EXTREMELY PAIN, is dead");
                }
            },
            { "Move (AddForce)", delegate
                {
                   RigBod.velocity += -transform.forward * 2;
                    Debug.Log($"Weeeee");
                }
            }
        };
    }
    
    // Removes health and calls OnPostHurt
    void Hurt(float healthPoints)
    {
        // Hurt shouldn't be able to heal,
        // 0 or more damage only
        CurHealth -= Mathf.Max(healthPoints, 0);
        OnPostHurt();
    }

    // void OnPostHurt(float healthOld, float healthNew)
    void OnPostHurt()
    {
        if (CurHealth <= 0)
        {
            Die();
        }
        else
        {
            Anim.Play("ghoul_gethit");
        }
    }
    
    void Die()
    {
        Anim.Play("ghoul_die");
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetFloat(CurVelocity, RigBod.velocity.magnitude);
    }

    private void OnGUI()
    {
        DebugButtons.ListButtons(_dbgBtnsDict);
    }
}
