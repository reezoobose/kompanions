using UnityEngine;
using UnityEngine.UI;

namespace _Script
{
    /// <inheritdoc />
    /// <summary>
    /// Updated Color .
    /// </summary>
    public class UpdatedColor : MonoBehaviour
    {
        [Header("Red color slider : ")]
        public Slider redSlider;
        [Header("Green color slider : ")]
        public Slider greenSlider;
        [Header("Blue color slider : ")]
        public Slider blueSlider;
        [Header("Apply Button.")]
        public Button applyColorButton;
        //Static reference.
        public static UpdatedColor UpdatedColorReference;

        [Header("Color will Be : ")]
        [SerializeField]private Color color;


        /// <summary>
        /// Awake The instance .
        /// </summary>
        private void Awake()
        {
            if (UpdatedColorReference == null)
            {
                UpdatedColorReference = this;
            }
        }

        /// <summary>
        /// Get Color .
        /// </summary>
        /// <returns></returns>
        public  Color GetColor()
        {

            var redPart = redSlider.value;
            var greenPart = greenSlider.value;
            var bluePart = blueSlider.value;
            return new Color(redPart,bluePart,greenPart);
        }

        /// <summary>
        /// Set Button Color.
        /// </summary>
        public void SetButtonColor()
        {
            if (applyColorButton == null) return;
            var selectedColor = GetColor();
            applyColorButton.GetComponent<Image>().color = selectedColor;
            color = selectedColor;
        }
    }
}
