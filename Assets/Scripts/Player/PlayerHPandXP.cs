using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerHPandXP : MonoBehaviour
    {
        // public RectTransform xpPanelReference;
        public TextMeshProUGUI HPText;
        public RectTransform HPPanel;
        public RectTransform XPPanel;

        // private TextMesh _hpText;
        // private RectTransform _hpRect;
        // private RectTransform _xpRect;
    
        public int healthMax = 100;
        private float _healthPercentageFract;
        private float _healthPercentage;

        private int _healthCur;
        public int HealthCur
        {
            get => _healthCur;
            set
            {
                OnHealthChange(_healthCur, value);
                _healthCur = value;
            }
        }
    
        private void OnHealthChange(int oldHealth, int newHealth) 
        {
            _healthPercentageFract = (float)newHealth / healthMax;
            _healthPercentage = (int)(_healthPercentageFract * 100);
        
            ScaleRect(HPPanel, _healthPercentageFract);
            HPText.text = $"HP: {_healthPercentage}%";
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
            _healthCur = healthMax;
            // _hpText = HPText.GetComponent<TextMesh>();
            // _hpRect = HPText.GetComponent<RectTransform>();
            // _xpRect = _xpRect.GetComponent<RectTransform>();
            HealthCur = 50;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
