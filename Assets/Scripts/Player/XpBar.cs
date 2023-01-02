using System;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public LevelSystem levelSystem;
    public Slider slider;

    private void Start()
    {
        OnExperienceUpdated(levelSystem.CurrentXp, levelSystem.XpPerLevel);
    }

    private void OnEnable()
    {
        if(levelSystem == null)
            return;
            
        levelSystem.experienceUpdated.AddListener(OnExperienceUpdated);
    }

    private void OnDisable()
    {
        if(levelSystem != null)
            levelSystem.experienceUpdated.RemoveListener(OnExperienceUpdated);
    }

    private void OnExperienceUpdated(int currentXp, int XpPerLevel)
    {
        SetXp2NextLevel(XpPerLevel);
        SetXpCurrent(currentXp);
    }

    public void SetXp2NextLevel(int xp)
    {
        slider.maxValue = xp;
        slider.value = xp;
    }

    public void SetXpCurrent(int xp)
    {
        slider.value = xp;
    }
}