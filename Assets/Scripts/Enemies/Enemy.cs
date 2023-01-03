using JetBrains.Annotations;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(Collider))]
    [RequireComponent(typeof(IMovement))]
    public class Enemy : NPC /*, IHealth */
    {
        // Animation
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private Animator _anim;

        [Header("Stats")] 
        [Range(1, 100)] public float damage = 7;
        [Range(1, 500)] public float maxHealth = 100;
        [Range(1, 5000)] public int msBetweenAttacks = 500;
        [Range(1, 5000)] public float attackRange = 1;

        private float _curHealth;

        // Movement
        private IMovement _movement;

        [Header("AI")] private Rigidbody _rigBod;
        [CanBeNull] public GameObject CurAttackTargetRef { get; set; }

        // private bool shouldPlayAnimRun = false;

        // [Header("Animations")]
        // public 

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
            _movement.OnNavigationStateChanged += newIsNavigating => _anim.SetBool(IsRunning, newIsNavigating);
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
                OnPostHurt();
            }
        }

        // void OnPostHurt(float healthOld, float healthNew)
        private void OnPostHurt()
        {
        }

        private void Die()
        {
            _anim.Play("die");
        }

        void PerformAttack()
        {
            // Yes, I believe this is a code smell.
            // Yes, this could have been part of a single reusable piece of code with its own class/namespace.
            bool hasTargetRef = CurAttackTargetRef != null;
            if (!hasTargetRef)
            {
                Debug.LogWarning($"{nameof(PerformAttack)} was called from Enemy #{GetInstanceID()} with no target");
                return;
            } 
            
            bool isTargetWithinRange = EnemyMovement.IsDistanceWithinThreshold(transform.position,
                CurAttackTargetRef.transform.position, attackRange);
            
            if (isTargetWithinRange)
            {
                _anim.Play("attack");
            }
            else
            {
                // _movement.MoveNear();
            }
            
            // if (CurAttackTargetRef is TODO: Player player) { player.Hurt(damage) }
        }

        [ContextMenu("Test - Deal 35 Damage")]
        public void TestHurt35()
        {
            Hurt(35);
        }

        [ContextMenu("Test - Move to a random location")]
        public void TestMoveNear()
        {
            var randPos = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
            _movement.MoveNear(randPos, 1f);
        }
    }
}