using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    public void SetManaMax(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    public void SetManaCurrent(int mana)
    {
        slider.value = mana;
    }

}
