using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBars_HP_XP : MonoBehaviour
{
    public RectTransform XPPanelReference;
    public TextMesh HPTextReference;
    public RectTransform HPPanelReference;

    public int healthMax = 100;
    private int _healthPercentage;
    private float _healthPercentageNorm;

    private float hpPanelMaxWidth;
    private float xpPanelMaxWidth;
    
    private int _healthCur;
    public int HealthCur
    {
        get => _healthCur;
        set
        {
            _healthPercentageNorm = (float)value / healthMax;
            _healthPercentage = (int)_healthPercentageNorm * 100;

            Rect newHpBarRect = HPPanelReference.rect;
            // newHpBarRect.width = hpPanelMaxWidth * _healthPercentageNorm;
            
            // HPPanelReference.rect.width = newHpBarRect;
            HPTextReference.text = $"HP: {_healthPercentage}%";
            _healthCur = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (HPTextReference is { })
            throw new NullReferenceException("HP Text Reference is required");
        
        if (HPPanelReference is { })
            throw new NullReferenceException("HP Panel Reference is required");
        
        if (XPPanelReference is { })
            throw new NullReferenceException("XP Panel Reference is required");

        
        hpPanelMaxWidth = HPPanelReference.rect.width;
        xpPanelMaxWidth = XPPanelReference.rect.width;
        
        // has to be set after other things ahve been initialized
        HealthCur = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
