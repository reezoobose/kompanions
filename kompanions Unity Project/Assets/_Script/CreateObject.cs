using System;
using UnityEngine;

namespace _Script
{
    /// <inheritdoc />
    /// <summary>
    ///     Create Object runtime .
    /// </summary>
    public class CreateObject : MonoBehaviour
    {
        [Header("Select The Object :")] public PrimitiveType selectedObjectType;

        [Header("Initial Scale :")] [Range(0.3f, 2f)]
        public float initialScale;

        [Header("Where It will be created : ")]
        public Vector3 positionInWorld;

        [Header("Initial Color.")] public Color initialColor;
        [Header("Object  Y : ")] public float objectY;

        private const string ObjectTag = "Block";
        private int _creationTracker;

        /// <summary>
        ///     Create Primitive .
        /// </summary>
        /// <returns></returns>
        public GameObject CreatePrimitive()
        {
            var primaryObject = GameObject.CreatePrimitive(selectedObjectType);
            primaryObject.transform.position = new Vector3(positionInWorld.x, objectY, positionInWorld.z);
            primaryObject.transform.rotation = Quaternion.identity;
            primaryObject.name = ObjectTag + " + " + _creationTracker;
            primaryObject.tag = ObjectTag;
            primaryObject.transform.localScale = new Vector3(initialScale, initialScale, initialScale);
            _creationTracker++;
            SetVisual(primaryObject);
            AddPhysicsComponents(primaryObject);
            return primaryObject;
        }

        /// <summary>
        /// Add Physics components .
        /// </summary>
        private static void AddPhysicsComponents( GameObject newBornObject)
        {
            var rigidBody = newBornObject.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
            newBornObject.AddComponent<BoxCollider>();
        }

        /// <summary>
        ///     Set Visual color.
        /// </summary>
        /// <param name="selectedObject"></param>
        private void SetVisual(GameObject selectedObject)
        {
            var selectedShader = Shader.Find("Standard");
            var newMaterial = new Material(selectedShader)
            {
                color = initialColor,
                name = ObjectTag + " + " + (_creationTracker - 1) + "Material"
            };
            selectedObject.GetComponent<Renderer>().sharedMaterial = newMaterial;
        }
    }
}