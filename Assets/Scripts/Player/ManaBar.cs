using UnityEngine;
using UnityEngine.UI;

namespace Player
{
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
}