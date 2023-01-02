// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace Developer
// {
//     public static class DevDebugBtnList
//     {
//         // private static int _btnLastEnd = BtnFirstY + BtnHeight;
//         private const int BtnFirstX = 8, BtnFirstY = 8, BtnWidth = 150, BtnHeight = 20;
//         
//         public static void DrawBtnDict(Dictionary<string, Action> btnTextFunc)
//         {
//             int btnOffsetY = 0; // used to offset buttons so they dont overlap
//             foreach (var (btnText, btnFunc) in btnTextFunc)
//             {
//                 if (GUI.Button(new Rect(BtnFirstX, BtnFirstY + btnOffsetY, BtnWidth, BtnHeight), btnText))
//                 {
//                     btnFunc();
//                 }
//                 btnOffsetY += BtnHeight;
//             }
//         }
//     }
// }
