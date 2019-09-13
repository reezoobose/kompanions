using UnityEditor;
using UnityEngine;

namespace _Script.Editor
{
    [CustomEditor(typeof(CreateObjectInABatch))]
    public class CreateObjectInaBatchEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var createObjectInABatchReference = (CreateObjectInABatch)target;
            GUILayout.Space(20);
            {
                //Editor Button .
                if (!GUILayout.Button("Create Primitive Object In Batch")) return;
                if (EditorApplication.isPlaying)
                {
                    createObjectInABatchReference.PerformBatchCreation();
                }
            }

        }
    }
}

