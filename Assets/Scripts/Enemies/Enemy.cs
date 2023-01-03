using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemies
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(Collider))]
    [RequireComponent(typeof(IMovement))]
    public class Enemy : NPC /*, IHealth */
    {
        // Public State
        [CanBeNull]
        public GameObject CurAttackTargetRef
        {
            get => _curAttackTargetRef;
            set
            {
                Debug.Log("[ENEMY] Set Target Ref");
                _hasAttackTarget = value is not null;
                _curAttackTargetRef = value; 
            }
        }
        

        // Animation
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private Animator _anim;

        [Header("Stats")] 
        [Range(1, 5000)] public float attackRange = 1;
        [Range(1, 100)] public float damage = 7;
        [Range(1, 500)] public float maxHealth = 100;
        [Range(0.05f, 10), Tooltip("Time between attacks")] public float attackBasicDelayBetween = 0.2f;
        [Range(0.01f, 2), Tooltip("Delay to execute hit logic from animation start")] public float attackBasicDelayApex = 0.1f;

        // Private State
        [CanBeNull] private GameObject _curAttackTargetRef; // backing field
        private bool _hasAttackTarget; // null checking is "expensive", use bool instead
        private float _nextAttackTime; // time when next attack will be performed
        private float _curHealth;
        private bool _isCurrentlyRunning;

        // Movement
        private IMovement _movement;

        private Rigidbody _rigBod;

        private void Awake()
        {
            // NPC Values
            _curHealth = maxHealth;

            // Components
            _anim = GetComponent<Animator>();
            _rigBod = GetComponent<Rigidbody>();
            _movement = GetComponent<IMovement>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log("Has Movement comp: " + _movement);
            
            // Subscribe to the movement components OnNavigationStateChanged with a callback that sets IsRunning to
            // the value returned from the event
            _movement.OnNavigationStateChanged += newIsNavigating =>
            {
                _anim.SetBool(IsRunning, newIsNavigating);
                _isCurrentlyRunning = newIsNavigating;
            };
        }

        // Removes health, plays animation and calls OnPostHurt if the unit didn't die
        private void Hurt(float healthPoints)
        {
            // Hurt shouldn't be able to heal,
            // 0 or more damage only
            _curHealth -= Mathf.Max(healthPoints, 0);

            if (_curHealth <= 0)
            {
                Die();
            }
            else
            {
                _anim.Play("gethit");
            }
        }

        private void Die()
        {
            _anim.Play("die");
        }

        private bool AttackTargetWithinRange()
        {
            
            return EnemyMovement.IsDistanceWithinThreshold(transform.position,
                CurAttackTargetRef.transform.position, attackRange);
  
        }

        private void Update()
        {
            // Debug.Log($"{_hasAttackTarget}, {_nextAttackTime} < {Time.time}");
            // Attack conditionals:
            if (!_hasAttackTarget // we have a target 
                || !(Time.time > _nextAttackTime))  // basic attack isn't on cooldown 
                return;

            // we're not running and we're close enough to the target
            if (!_isCurrentlyRunning && AttackTargetWithinRange())
            {
                Debug.Log("Attack!!");
                _nextAttackTime = Time.time + attackBasicDelayBetween;
                StartCoroutine( PerformBasicAttack(CurAttackTargetRef, attackBasicDelayApex) );
            }
            else if (!_isCurrentlyRunning) // enemy is too far away and we're not already running: start running
            {
                Debug.Log("Running!!!");
                _movement.MoveNear(CurAttackTargetRef.transform.position, attackRange);
            }
        }
        
        /*
         * Attacking & Targetting
         */
        
        void OnAttackBegin(GameObject attackTarget)
        {
            Debug.Assert(_hasAttackTarget); // make a stink if we don't have a target

            _anim.Play("attack");
        }

        void OnAttackApex(GameObject attackTarget)
        {
            bool isTargetWithinRange = EnemyMovement.IsDistanceWithinThreshold(transform.position,
                attackTarget.transform.position, attackRange);
            
            if (isTargetWithinRange)
            {
                // TODO: Run damage logic, if we had an interface I could've implemented that :)
                // if (CurAttackTargetRef is Player player) { player.Hurt(damage) }
            }
            // Maybe later:
            // else { OnAttackMiss() }
        }

        private IEnumerator PerformBasicAttack(GameObject attackTarget, float attackApexDelay)
        {
            
            OnAttackBegin(attackTarget);
            yield return new WaitForSeconds(attackApexDelay);
            OnAttackApex(attackTarget);
        }

        /*
         *  Testing
         */
        
        [ContextMenu("Test - Deal 35 Damage")]
        public void TestHurt35()
        {
            Hurt(35);
        }

        [ContextMenu("Test - Move to a random location")]
        public void TestMoveNear()
        {
            var randPos = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
            _movement.MoveNear(randPos, attackRange);
        }
        
        [ContextMenu("Test - Attack object named 'Cube'")]
        public void TestAttackCube()
        {
            Debug.Log("[ENEMY] Test Attack Cube");
            GameObject attackTestCube = GameObject.Find("Cube");
            CurAttackTargetRef = attackTestCube;
            Debug.Log($"[ENEMY] Attack Cube: {CurAttackTargetRef}");
            
        }
        
        [ContextMenu("Test - Stop Attacking'")]
        public void TestStopAttacking()
        {
            Debug.Log("[ENEMY] Test - Stop Attacking");
            CurAttackTargetRef = null;
        }
    }
}