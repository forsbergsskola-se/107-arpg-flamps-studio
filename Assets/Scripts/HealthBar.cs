using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealthMax(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealthCurrent(int health)
    {
        slider.value = health;
    }
}