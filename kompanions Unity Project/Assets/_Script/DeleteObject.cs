using UnityEngine;

namespace _Script
{
    [RequireComponent(typeof(Move))]
    public class DeleteObject : MonoBehaviour
    {
        private Move _selected;

        private void Awake()
        {
            _selected = GetComponent<Move>();
        }

        /// <summary>
        /// Delete .
        /// </summary>
        public void Delete()
        {
            if (_selected.selectedObject == null) return;
            Destroy(_selected.selectedObject);
        }
    }
}