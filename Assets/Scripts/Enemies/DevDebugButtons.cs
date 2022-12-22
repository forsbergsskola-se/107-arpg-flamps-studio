using System;
using System.Collections.Generic;
using UnityEngine;

public static class DebugButtons
{

    public static void ListButtons(Dictionary<string, Action> btnTextFunc)
    {
        const int btnFirstX = 8, btnFirstY = 8, btnWidth = 150,btnHeight = 20; 
        
        int nextOffset = 0;
        foreach (var (btnText, btnFunc) in btnTextFunc)
        {
            if (GUI.Button(new Rect(btnFirstX, btnFirstY+nextOffset, btnWidth, btnHeight), btnText))
            {
                btnFunc();
            }

            nextOffset += btnHeight;
        }
        
    }
    
    
    
}
