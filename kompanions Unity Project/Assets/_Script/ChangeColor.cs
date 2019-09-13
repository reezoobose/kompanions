using UnityEngine;

namespace _Script
{
    [RequireComponent(typeof(Move))]
    public class ChangeColor : MonoBehaviour
    {

        private Move _selected;

        private static Color GetColor => UpdatedColor.UpdatedColorReference.GetColor();

        private void Awake()
        {
            _selected = GetComponent<Move>();
        }

        /// <summary>
        /// Change color
        /// </summary>
        public void ChangeColorOverUi( )
        {
            if (_selected.selectedObject == null) return;
            _selected.selectedObject.GetComponent<Renderer>().sharedMaterial.color 
                = GetColor;
        }
    }
}
