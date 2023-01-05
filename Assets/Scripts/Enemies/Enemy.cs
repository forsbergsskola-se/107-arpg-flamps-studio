using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(Collider))]
    [RequireComponent(typeof(IMovement))]
    public class Enemy : MonoBehaviour /*, IHealth */
    {
        // Animation
        private static readonly int AnimBoolIsRunning = Animator.StringToHash("isRunning");
        private static readonly int AnimTrigAttack = Animator.StringToHash("Attack");
        private static readonly int AnimTrigDie = Animator.StringToHash("Die");
        private static readonly int AnimTrigGetHit = Animator.StringToHash("GetHit");

        [Header("Stats")] [Range(1, 5000)] [Tooltip("Checked on attack apex, miss if larger than this")]
        public float attackDistanceMiss = 3;

        [Range(1, 5000)] [Tooltip("Stand when attacking")]
        public float attackDistanceStart = 1;

        [Range(1, 100)] public float attackDamage = 7;
        [Range(1, 500)] public float healthMax = 100;

        [Range(0.05f, 10)] [Tooltip("Time between attacks")]
        public float attackDelayBetween = 0.2f;

        [Range(0.01f, 2)] [Tooltip("Delay to execute hit logic from animation start")]
        public float attackDelayApex = 0.1f;

        public bool playAudioOnAlert = true;
        public bool playAudioOnAttack = true;
        public bool playAudioOnDeath = true;
        private Animator _anim;

        // Private State
        [CanBeNull] private GameObject _curAttackTargetRef; // backing field
        private bool _hasAttackTarget; // null checking is "expensive", use bool instead
        private float _healthCur;


        // Movement
        private IMovement _movement;
        private float _nextAttackTime; // time when next attack will be performed

        private Rigidbody _rigBod;

        // Sound
        private EnemySound _sound;

        // Public State
        [CanBeNull]
        public GameObject CurAttackTargetRef
        {
            get => _curAttackTargetRef;
            set
            {
                // Debug.Log("[ENEMY] Setting Target Reference");
                _hasAttackTarget = value is not null;
                // Debug.Log($"[ENEMY] hasAttackTarget: {_hasAttackTarget}");
                if (_hasAttackTarget && playAudioOnAlert) _sound.PlayAudioAlert();
                _curAttackTargetRef = value;
            }
        }


        private void Awake()
        {
            // NPC Values
            _healthCur = healthMax;

            // Components
            _anim = GetComponent<Animator>();
            _rigBod = GetComponent<Rigidbody>();
            _movement = GetComponent<IMovement>();
            _sound = GetComponent<EnemySound>();
        }

        private void Update()
        {
            _anim.SetBool(AnimBoolIsRunning,
                _isNavigating()); // set if changed; unsure of the overhead of this is worth it

            // Debug.Log($"{_hasAttackTarget}, {_nextAttackTime} < {Time.time}");
            // Attack conditionals:
            if (!_hasAttackTarget) // make sure we have a target; otherwise do nothing
                return;

            var basicAttackOnCooldown = _nextAttackTime > Time.time;

            if (!_isNavigating() && TargetWithinAttackStartRange() && !basicAttackOnCooldown)
            {
                Debug.Log("Target is in range, we're not on a path");
                _nextAttackTime = Time.time + attackDelayBetween;
                StartCoroutine(PerformBasicAttack(CurAttackTargetRef, attackDelayApex));
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

        private bool _isNavigating()
        {
            return _movement.IsNavigating;
        }

        // Removes health, plays animation and calls OnPostHurt if the unit didn't die
        private void Hurt(float healthPoints)
        {
            // Hurt shouldn't be able to heal,
            // 0 or more damage only
            _healthCur -= Mathf.Max(healthPoints, 0);

            if (_healthCur <= 0)
                Die();
            else
                _anim.SetTrigger(AnimTrigGetHit);
        }

        private void Die()
        {
            _anim.SetTrigger(AnimTrigDie);
            if (playAudioOnDeath) _sound.PlayAudioDeath();
        }

        // Note: doesn't account for size, collision, bounds or offset from transform
        private bool TargetWithinDistance(float distance)
        {
            return (transform.position - CurAttackTargetRef.transform.position).sqrMagnitude < Mathf.Pow(distance, 2); // sqr is faster
        }

        private bool TargetWithinAttackStartRange()
        {
            return TargetWithinDistance(attackDistanceStart);
        }

        private bool TargetWithinAttackHitRange()
        {
            return TargetWithinDistance(attackDistanceMiss);
        }

        /*
         * Attacking & Target
         */

        private void OnAttackBegin(GameObject attackTarget)
        {
            Debug.Assert(_hasAttackTarget); // make a stink if we don't have a target
            // Debug.Log("[ENEMY] OnAttackBegin() called");
            _anim.SetTrigger(AnimTrigAttack);

            if (playAudioOnAttack) _sound.PlayAudioAttack();
        }

        private void OnAttackApex(GameObject attackTarget)
        {
            if (TargetWithinAttackHitRange())
                Debug.Log($"Hit! on {attackTarget}");
            // TODO: Run damage logic, if we had an interface I could've implemented that :)
            // if (CurAttackTargetRef is Player player) { player.Hurt(damage) }
            else
                Debug.Log($"Missed! on {attackTarget}");
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
        /*
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
            var attackTestCube = GameObject.Find("Cube");
            CurAttackTargetRef = attackTestCube;
            Debug.Log($"[ENEMY] Attack Cube: {CurAttackTargetRef}");
        }

        [ContextMenu("Test - Stop Attacking")]
        public void TestStopAttacking()
        {
            Debug.Log("[ENEMY] Test - Stop Attacking");
            CurAttackTargetRef = null;
        }
        */
    }
}