using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class LevelSystem : MonoBehaviour
    {
        [SerializeField] public  int level;
        [SerializeField] private int xpPerLevel;
        public static int _curXp;
        public GameObject player;
        public UnityEvent<int, int> experienceUpdated;
        public UnityEvent<int> leveledUp;
        public HealthSystem healthSystem;
        public ManaSystem manaSystem;
        public int healthPerLevel;
        public int manaPerLevel;


        
        public int CurrentXp
        {
            get => _curXp;
            set
            {
                _curXp = Mathf.Clamp(value, 0, int.MaxValue);
                experienceUpdated?.Invoke(_curXp, XpPerLevel);
            }
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
                //healthSystem.IncreaseMaxHealth(healthPerLevel);
                //manaSystem.IncreaseMaxMana(manaPerLevel);
            }
        }
    }
}