using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerLevelDisplay : MonoBehaviour
    {
        public TextMeshProUGUI levelText;
        public LevelSystem levelSystem;

        private void Start()
        {
            OnLeveledUp(levelSystem.CurrentLevel);
            OnExperienceUpdated(levelSystem.CurrentXp, levelSystem.XpPerLevel);
        }

        private void OnEnable()
        {
            levelSystem.leveledUp.AddListener(OnLeveledUp);
            levelSystem.experienceUpdated.AddListener(OnExperienceUpdated);
        }

        private void OnDisable()
        {
            levelSystem.leveledUp.RemoveListener(OnLeveledUp);
            levelSystem.experienceUpdated.RemoveListener(OnExperienceUpdated);
        }

        private void OnLeveledUp(int currentLevel)
        {
            levelText.text = "Level: " + currentLevel;
        }
    
        private void OnExperienceUpdated(int currentXp, int xpRequired)
        {
            //update xp bar or whatever.
        }
    }
}