using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Developer
{
    public static class AnimatorControllerEditor
    {
        // Adds the context menu item
        [MenuItem("Assets/Helpers/Animation Replacement")]
        public static void ReplaceAnimations()
        {
            // redundant if check but
            //  1. I lowkey don't trust unity 
            //  2. Smooth pattern matching type casting
            if (Selection.activeObject is AnimatorController animatorController)
            {
                Debug.Log("[Helper] Initiating Replacement Dialog on: " + animatorController.name);
                Debug.Log("[]");
                // ShowWindow()
                // string inputText = "";
                // bool checkboxValue = false;
                // int result = EditorUtility.DisplayDialogComplex("My Dialog", "Enter some text and choose an option:",
                //     "Ok", "Cancel", "Apply");
                // if (result == 0)
                // {
                //     // User clicked "Ok"
                //     inputText = EditorUtility.TextField("Input", inputText);
                //     checkboxValue = EditorUtility.Toggle("Checkbox", checkboxValue);
                // }
                // else if (result == 1)
                // {
                //     // User clicked "Cancel"
                // }
                // else if (result == 2)
                // {
                //     // User clicked "Apply"
                // }
                
            }
            else
            {
                Debug.LogError("Somehow the IsAnimatorControllerSelected didn't work.");
            }
        }
    
        // https://docs.unity3d.com/ScriptReference/MenuItem-ctor.html
        // has to be true for the menu item to be enabled
        [MenuItem("Assets/Helpers/Animation Replacement", true)]
        public static bool IsAnimatorControllerSelected() => (Selection.activeObject is AnimatorController);
    }
}
