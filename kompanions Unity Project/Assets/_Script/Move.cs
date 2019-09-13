using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _Script
{
    public class Move : MonoBehaviour
    {
        [Header("Main Camera.")]
        public Camera mainCamera;
        [Header("How Far Ray will go")] public float rayCastDepth = 100f;
        private const string DetectionTag = "Block";
        public RaycastHit hitInfo;
        [Header("Selected Game Object")]
        public GameObject selectedObject;

        private float ZPosition => mainCamera.WorldToScreenPoint(selectedObject.transform.position).z;

        private bool IsObjectDetected =>
            Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition),
                out hitInfo,
                rayCastDepth) &&
            hitInfo.transform.CompareTag(DetectionTag);

        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;
            if (!IsObjectDetected) return;
            selectedObject = hitInfo.collider.gameObject;
            MoveOverMouse(Input.mousePosition);
        }


        private void MoveOverMouse(Vector3 position)
        {
            var newPosition = position;
            newPosition.z = ZPosition;
            selectedObject.transform.position = mainCamera.ScreenToWorldPoint(newPosition);
        }
    }
}
