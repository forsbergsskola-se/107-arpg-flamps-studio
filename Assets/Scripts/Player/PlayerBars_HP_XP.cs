using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBars_HP_XP : MonoBehaviour
{
    // public RectTransform xpPanelReference;
    public GameObject XPPanelGameObject;
    public GameObject HPTextGameObject;
    public GameObject HPPanelGameObject;

    private TextMesh _hpText;
    private RectTransform _hpRect;
    private RectTransform _xpRect;
    
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
            _healthPercentage = (int)_healthPercentageFract * 100;

            ScaleRect(_hpRect, _healthPercentageFract);
            _hpText.text = $"HP: {_healthPercentage}%";
    }

    private void ScaleRect(RectTransform rectTransform, int valCur, int valMax)
    {
        float percentageFract = Mathf.Clamp( (float)valCur / valMax, 0, 1 );
        rectTransform.localScale = new Vector3(1, percentageFract, 1); // cannot modify struct field directly
    }   
    
    private void ScaleRect(RectTransform rectTransform, float scaleY)
    {
        rectTransform.localScale = new Vector3(1, scaleY, 1); // cannot modify struct field directly
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _healthCur = healthMax;
        _hpText = HPTextGameObject.GetComponent<TextMesh>();
        _hpRect = HPTextGameObject.GetComponent<RectTransform>();
        _xpRect = HPTextGameObject.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
