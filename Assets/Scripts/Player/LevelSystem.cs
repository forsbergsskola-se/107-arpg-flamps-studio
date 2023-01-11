using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class LevelSystem : MonoBehaviour
    {
        [SerializeField] public int level;
        [SerializeField] private int xpPerLevel;
        private int _curXp;
        public GameObject player;
        public UnityEvent<int, int> experienceUpdated;
        public UnityEvent<int> leveledUp;
        public GameObject levelUpEffect;
        public HealthSystem healthSystem;
        public ManaSystem manaSystem;
        public int healthPerLevel;
        public int manaPerLevel;

        public int CurrentXp
        {
            get => _curXp;
            set => _curXp = value;
        }

        public int CurrentLevel
        {
            get => level;
            set
            {
                level = Mathf.Clamp(value, 0, int.MaxValue);
                leveledUp?.Invoke(level);
            }
        }

        public int XpPerLevel => xpPerLevel;

        public void AddXp(int amount)
        {
            _curXp += amount;
            experienceUpdated?.Invoke(_curXp, XpPerLevel);
            if (_curXp >= XpPerLevel)
            {
                LevelUp();
            }
        }
        public void SetXp(int amount)
        {
            _curXp = amount;
            experienceUpdated?.Invoke(_curXp, XpPerLevel);
            if (_curXp >= XpPerLevel)
            {
                LevelUp();
            }
        }
        private void LevelUp()
        {
            while (_curXp >= XpPerLevel)
            {
                CurrentLevel++;
                _curXp -= XpPerLevel;
                Instantiate(levelUpEffect, transform.position, Quaternion.identity);
                //healthSystem.IncreaseMaxHealth(healthPerLevel);
                //manaSystem.IncreaseMaxMana(manaPerLevel);
            }
        }
    }
}