using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(Collider))]
[RequireComponent(typeof(IMovement))]
public class Enemy : NPC /*, IHealth */
{
    [Header("Stats")]
    [Range(1, 100)] public float damage = 7;
    [Range(1, 500)] public float maxHealth = 100;
    [Range(1, 5000)] public int msBetweenAttacks = 500;
    [Range(1, 5000)] public float attackRange = 1;
    
    protected float CurHealth;
    
    [Header("AI")]
    protected Rigidbody RigBod;

    // Movement
    protected IMovement Movement;
    
    // Animation
    protected Animator Anim;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    // private bool shouldPlayAnimRun = false;
    
    // [Header("Animations")]
    // public 

    private void Awake()
    {
        // NPC Values
        CurHealth = maxHealth;
        
        // Components
        Anim = GetComponent<Animator>();
        RigBod = GetComponent<Rigidbody>();
        Movement = GetComponent<IMovement>();

      }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Has Movement comp: " + Movement);
        Movement.OnNavigationStateChanged += newIsNavigating => Anim.SetBool(IsRunning, newIsNavigating);
    
    }

    [ContextMenu("RANDOM MOVE TEST")]
    public void TestMoveNear()
    {
        var randPos = new Vector3(Random.Range(-20, 20),0, Random.Range(-20, 20));
        Movement.MoveNear( randPos, 1f );
    }
    
    // Removes health, plays animation and calls OnPostHurt if the unit didn't die
    void Hurt(float healthPoints)
    {
        // Hurt shouldn't be able to heal,
        // 0 or more damage only
        CurHealth -= Mathf.Max(healthPoints, 0);
        
        if (CurHealth <= 0)
        {
            Die();
        }
        else
        {
            Anim.Play("gethit");
            OnPostHurt();
        }
    }

    // void OnPostHurt(float healthOld, float healthNew)
    void OnPostHurt()
    {
        
    }

    void Die()
    {
        Anim.Play("die");
    }

    
    
    // Update is called once per frame
    void Update()
    {
        // Anim.SetBool(IsRunning, shouldPlayAnimRun);
    }
}