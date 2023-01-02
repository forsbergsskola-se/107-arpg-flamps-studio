using System.IO;
using UnityEditor;
using UnityEngine;

namespace Developer
{
    public class AnimationReplacementWindow : EditorWindow
    {
        private string[] _filesUsedForReplacement;
        private string[] _fileNames;
        private bool[] _fileCheckboxes;

        [MenuItem("Assets/Helpers/Animation Replacement Window")]
        public static void ShowWindow()
        {
            var window = GetWindow<AnimationReplacementWindow>();
            window.Show();
        }

        private void OnGUI()
        {
            // Directory input field
            // _filesUsedForReplacement = EditorGUILayout.TextField("Directory", _filesUsedForReplacement);
            if (GUILayout.Button("Browse"))
            {
                _filesUsedForReplacement = EditorUtility.OpenFilePanelWithFilters("Select Animations to Use", "", "anim");
            }

            // Get the file names in the directory
            // _fileNames = Directory.GetFiles(_filesUsedForReplacement);

            // Initialize the file checkboxes array
            _fileCheckboxes = new bool[_filesUsedForReplacement.Length];

            // Display the file names with checkboxes
            for (int i = 0; i < _fileNames.Length; i++)
            {
                _fileCheckboxes[i] = EditorGUILayout.Toggle(Path.GetFileName(_fileNames[i]), _fileCheckboxes[i]);
            }

            if (GUILayout.Button("Confirm"))
            {
                // Use the file checkbox values
                for (int i = 0; i < _fileCheckboxes.Length; i++)
                {
                    Debug.Log(_fileNames[i] + ": " + _fileCheckboxes[i]);
                }
            }

            if (GUILayout.Button("Cancel"))
            {
                // Close the editor window
                this.Close();
            }
        }
    }
}