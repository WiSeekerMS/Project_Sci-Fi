using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Platform.Editor
{
    [CustomEditor(typeof(PlatformCreator))]
    public class PlatformCreatorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var creator = target as PlatformCreator;
            if (GUILayout.Button("Create"))
            {
                creator?.Create();
            }
        }
    }
}
