using UnityEditor;
using UnityEngine;

namespace _Script.Editor
{
    [CustomEditor(typeof(CreateObject))]
    public class CreateObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var createObjectReference = (CreateObject) target;
            GUILayout.Space(20);
            if (!GUILayout.Button("Create Primitive Object")) return;
            createObjectReference.CreatePrimitive();
        }

    }
}
