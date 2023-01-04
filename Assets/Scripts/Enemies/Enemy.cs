using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
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
                Debug.Log("[ENEMY] Setting Target Reference");
                _hasAttackTarget = value is not null;
                Debug.Log($"[ENEMY] hasAttackTarget: {_hasAttackTarget}");
                _curAttackTargetRef = value; 
            }
        }
        

        // Animation
        private static readonly int AnimBoolIsRunning = Animator.StringToHash("isRunning");
        private static readonly int AnimTrigAttack = Animator.StringToHash("Attack");
        private static readonly int AnimTrigDie = Animator.StringToHash("Die");
        private static readonly int AnimTrigGetHit = Animator.StringToHash("GetHit");
        private Animator _anim;

        [Header("Stats")] 
        [Range(1, 5000), Tooltip("Checked on attack apex, miss if larger than this")] public float attackDistanceMiss = 3;
        [Range(1, 5000), Tooltip("Stand when attacking")] public float attackDistanceStart = 1;
        [Range(1, 100)] public float attackDamage = 7;
        [Range(1, 500)] public float healthMax = 100;
        [Range(0.05f, 10), Tooltip("Time between attacks")] public float attackDelayBetween = 0.2f;
        [Range(0.01f, 2), Tooltip("Delay to execute hit logic from animation start")] public float attackDelayApex = 0.1f;

        // Private State
        [CanBeNull] private GameObject _curAttackTargetRef; // backing field
        private bool _hasAttackTarget; // null checking is "expensive", use bool instead
        private float _nextAttackTime; // time when next attack will be performed
        private float _healthCur;

        private bool _isNavigating() => _movement.IsNavigating;

        
        // Movement
        private IMovement _movement;

        private Rigidbody _rigBod;


        private void Awake()
        {
            // NPC Values
            _healthCur = healthMax;

            // Components
            _anim = GetComponent<Animator>();
            _rigBod = GetComponent<Rigidbody>();
            _movement = GetComponent<IMovement>();
        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Removes health, plays animation and calls OnPostHurt if the unit didn't die
        private void Hurt(float healthPoints)
        {
            // Hurt shouldn't be able to heal,
            // 0 or more damage only
            _healthCur -= Mathf.Max(healthPoints, 0);

            if (_healthCur <= 0)
            {
                Die();
            }
            else
            {
                _anim.SetTrigger(AnimTrigGetHit);
            }
        }

        private void Die()
        {
            _anim.SetTrigger(AnimTrigDie);
        }

        // Note: doesn't account for size or offset
        private bool TargetWithinDistance(float distance)
        {
            return (transform.position - CurAttackTargetRef.transform.position).sqrMagnitude < Mathf.Pow(distance, 2) ;
        }
        
        private bool TargetWithinAttackStartRange() => TargetWithinDistance(attackDistanceStart);
        private bool TargetWithinAttackHitRange() => TargetWithinDistance(attackDistanceMiss);

        private void Update()
        {
            _anim.SetBool(AnimBoolIsRunning, _isNavigating()); // set if changed; unsure of the overhead of this is worth it
                
            // Debug.Log($"{_hasAttackTarget}, {_nextAttackTime} < {Time.time}");
            // Attack conditionals:
            if (!_hasAttackTarget) // make sure we have a target; otherwise do nothing
                return;
            
            bool basicAttackOnCooldown = (_nextAttackTime > Time.time);
            
            if (!_isNavigating() && TargetWithinAttackStartRange() && !basicAttackOnCooldown)
            {
                Debug.Log("Target is in range, we're not on a path");
                _nextAttackTime = Time.time + attackDelayBetween;
                StartCoroutine( PerformBasicAttack(CurAttackTargetRef, attackDelayApex) );
            } 
            else if (!TargetWithinAttackStartRange()) // no range, move closer
            {
                // Debug.Log("Running!!!");
                _movement.UpdateDestination(CurAttackTargetRef.transform.position, attackDistanceStart);
                
            } 
            else if (basicAttackOnCooldown) // we're in range but attack is on cooldown 
            {
                // do nothing
            }
        }
        
        /*
         * Attacking & Target
         */
        
        void OnAttackBegin(GameObject attackTarget)
        {
            Debug.Assert(_hasAttackTarget); // make a stink if we don't have a target
            Debug.Log("[ENEMY] OnAttackBegin() called");
            _anim.SetTrigger(AnimTrigAttack);
        }

        void OnAttackApex(GameObject attackTarget)
        {
            if ( TargetWithinAttackHitRange() )
            {
                Debug.Log($"Hit! on {attackTarget}");
                // TODO: Run damage logic, if we had an interface I could've implemented that :)
                // if (CurAttackTargetRef is Player player) { player.Hurt(damage) }
            }
            else
            {
                Debug.Log($"Missed! on {attackTarget}");
            }
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
            _movement.UpdateDestination(randPos, attackDistanceStart);
        }
        
        [ContextMenu("Test - Attack object named 'Cube'")]
        public void TestAttackCube()
        {
            Debug.Log("[ENEMY] Test Attack Cube");
            GameObject attackTestCube = GameObject.Find("Cube");
            CurAttackTargetRef = attackTestCube;
            Debug.Log($"[ENEMY] Attack Cube: {CurAttackTargetRef}");
            
        }
        
        [ContextMenu("Test - Stop Attacking")]
        public void TestStopAttacking()
        {
            Debug.Log("[ENEMY] Test - Stop Attacking");
            CurAttackTargetRef = null;
        }
    }
}