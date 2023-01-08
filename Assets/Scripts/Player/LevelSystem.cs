using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Player
{
    public class LevelSystem : MonoBehaviour
    {
        [SerializeField] public static int level;
        [SerializeField] private int xpPerLevel;
        public static int _curXp;
        public GameObject player;
        public GameObject levelUpPrefab;
    
        public UnityEvent<int, int> experienceUpdated;
        public UnityEvent<int> leveledUp;
        public HealthSystem healthSystem;
        public ManaSystem manaSystem;
        public int healthPerLevel;
        public int manaPerLevel;


        private GameObject levelUpEffect;
        
        public int CurrentXp
        {
            get => _curXp; 
            private set
            {
                _curXp = Mathf.Clamp(value, 0, int.MaxValue);
                experienceUpdated?.Invoke(_curXp, XpPerLevel);
            }
        }

        public int CurrentLevel
        {
            get => level;
            private set
            {
                level = Mathf.Clamp(value, 0, int.MaxValue);
                leveledUp?.Invoke(level);
            }
        }

        public int XpPerLevel => xpPerLevel;

        public void AddXp(int amount)
        {
            CurrentXp += amount;
            if (CurrentXp >= XpPerLevel)
            {
                LevelUp();
            }
        }
        private void LevelUp()
        {
            while (CurrentXp >= XpPerLevel)
            {
                CurrentLevel++;
                CurrentXp -= XpPerLevel;
                if (levelUpEffect == null)
                {
                    levelUpEffect = Instantiate(levelUpPrefab, player.transform.position, transform.rotation);
                    StartCoroutine(DestroyLevelUpEffect(5f));
                }
            }
        }

        private IEnumerator DestroyLevelUpEffect(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(levelUpEffect);
            levelUpEffect = null;
        }

        void Update()
        {
            if (levelUpEffect != null)
            {
                levelUpEffect.transform.position = player.transform.position;
            }
        }
    }
}