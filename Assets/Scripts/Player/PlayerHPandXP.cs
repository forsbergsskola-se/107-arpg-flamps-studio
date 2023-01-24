using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHPandXP : MonoBehaviour
    {
        // public RectTransform xpPanelReference;
        public TextMeshProUGUI HPText;
        public TextMeshProUGUI XPText;
        
        public RectTransform HPPanel;
        public RectTransform XPPanel;
       
        public Image youDiedImage;
        
        // private TextMesh _hpText;
        // private RectTransform _hpRect;
        // private RectTransform _xpRect;
    
        public int healthMax = 100;
        public int xpToLevelInitial = 100;
        public float xpToLevelMultiplier = 1.5f;
        
        private int _lvlCur;
        private int _healthCur;
        
        private int _xpCurLvlRelative;
        private int _xpForLastLevel;
        
        private int _xpNextLevelTotal;

        private int _xpCur;
        public int XPCur
        {
            get => _xpCur;
            set
            {
                OnXPChange(value);
                _xpCur = value;
            }
        }
        
        public int HealthCur
        {
            get => _healthCur;
            set
            {
                OnHealthChange(value);
                _healthCur = value;
            }
        }
    
        private void OnHealthChange(int newHealth)
        {
            if (newHealth <= 0)
            {
                youDiedImage.enabled = true;
                return;
            }
            
            float healthPercentageFract = (float)newHealth / healthMax;
            int healthPercentage = (int)(healthPercentageFract * 100);
        
            ScaleRect(HPPanel, healthPercentageFract);
            HPText.text = $"HP: {healthPercentage}%";
        }
        

        private void OnXPChange(int newTotalXP)
        {
            if (newTotalXP >= _xpNextLevelTotal)
            {
                _lvlCur++;
                _xpForLastLevel = _xpNextLevelTotal;
                _xpNextLevelTotal = (int)(_xpNextLevelTotal * xpToLevelMultiplier);
            }
            if (newTotalXP >= _xpNextLevelTotal) OnXPChange(newTotalXP); // If we still have enough xp to level, call again

            // relative being: relative to current level
            int xpLeftTillLevel = _xpNextLevelTotal - _xpForLastLevel;
            int xpAwayFromLastLevel = newTotalXP - _xpForLastLevel;
            
            float xpCurProgressFract = (float)xpAwayFromLastLevel / xpLeftTillLevel;
            // float xpPercentage = (xpPercentageFract * 100);

            Debug.Log($"xpCurProgressFract:  {xpCurProgressFract}");
            Debug.Log($"xpLeftTillLevel:     {xpLeftTillLevel}");
            Debug.Log($"xpAwayFromLastLevel: {xpAwayFromLastLevel}");
            Debug.Log($"xpLeftTillLevel:     {xpLeftTillLevel}");
            // Debug.Log($"newTotalXP:          {newTotalXP}");
            // Debug.Log($"XPCur:               {XPCur}");
            
            ScaleRect(XPPanel, xpCurProgressFract);
            XPText.text = $"Level: {_lvlCur} (XP: {newTotalXP} / {_xpNextLevelTotal})";
        }

        private void ScaleRect(RectTransform rectTransform, int valCur, int valMax)
        {
            float percentageFract = Mathf.Clamp( (float)valCur / valMax, 0, 1 );
            rectTransform.localScale = new Vector3(percentageFract, 1, 1); // cannot modify struct field directly
        }
    
        private void ScaleRect(RectTransform rectTransform, float scaleX)
        {
            rectTransform.localScale = new Vector3(scaleX, 1, 1); // cannot modify struct field directly
        }
    
        // Start is called before the first frame update
        void Start()
        {
            HealthCur = healthMax;
            youDiedImage.enabled = false;

            _lvlCur = 1;
            
            _xpNextLevelTotal = xpToLevelInitial;
            XPCur = 0;
            
            // _hpText = HPText.GetComponent<TextMesh>();
            // _hpRect = HPText.GetComponent<RectTransform>();
            // _xpRect = _xpRect.GetComponent<RectTransform>();
            // HealthCur = 50;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
