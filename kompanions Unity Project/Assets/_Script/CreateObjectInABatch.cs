using UnityEngine;
using System.Collections.Generic;

namespace _Script
{
    /// <inheritdoc />
    /// <summary>
    ///     A bunch of object will be created in a grid .
    /// </summary>
    [RequireComponent(typeof(CreateObject))]
    public class CreateObjectInABatch : MonoBehaviour
    {
        #region Public feild.

        [Header("From Where Object Will be created : ")]
        public Transform rowStartPosition;

        [Header("Number of object will be created in Batch:  ")] [Range(1, 12)]
        public int numberOfObjectWillBeCreatedInaBatch = 3;

        [Header("Offset In X")] [Range(0f, 1f)]
        public float xAxisOffset;

        [Header("Offset In Y")] [Range(0f, 5f)]
        public float yAxisOffset;

        [Header("The scale of the objects :")]
        public List<float> objectScales;

        #endregion

        #region Private Field and properties

        private const int NumberOfObjectsInRow = 3;
        private const float DefaultScale = 2f;
        private float _shiftOverXAxis;
        private float _shiftOverYAxis;
        private float _shiftOverYAxisOnProcess;
        private int _numberOfObjectAlreadyCreated;
        private CreateObject _objectMachine;
        private float XStoredPosition { get; set; }
        private float YStoredPosition { get; set; }
        private float ZStoredPosition { get; set; }

        #endregion

        private void Awake()
        {
            _objectMachine = GetComponent<CreateObject>();
        }

        private void Start()
        {
            PerformBatchCreation();
        }

        /// <summary>
        ///     Create Object in batch.
        /// </summary>
        public void PerformBatchCreation()
        {
            for (_numberOfObjectAlreadyCreated = 0;
                _numberOfObjectAlreadyCreated <
                numberOfObjectWillBeCreatedInaBatch;
                _numberOfObjectAlreadyCreated++)
                SetupObject();
        }

        /// <summary>
        ///     Set Up object .
        /// </summary>
        private void SetupObject()
        {
            _objectMachine.selectedObjectType = PrimitiveType.Cube;
            _objectMachine.positionInWorld = SetUpPosition();
            _objectMachine.objectY = YStoredPosition;
            _objectMachine.initialColor = SetUpColor();
            _objectMachine.initialScale = SetUpscale();
            var createdGameObject = _objectMachine.CreatePrimitive();
            var rend = createdGameObject.GetComponent<Renderer>();
            if (rend == null) return;
            UpdateShiftOverXAxis(rend);
            UpdateShiftOverYAxis(rend);
        }


        /// <summary>
        /// Set up scale .
        /// </summary>
        /// <returns></returns>
        private float SetUpscale()
        {
            if(_numberOfObjectAlreadyCreated > objectScales.Count - 1)return DefaultScale;
            var scale = objectScales[_numberOfObjectAlreadyCreated];
            return scale;
            
        }


        /// <summary>
        ///     Set up position of object  .
        /// </summary>
        private Vector3 SetUpPosition()
        {
            var initialPosition = rowStartPosition.transform.position;
            var column = _numberOfObjectAlreadyCreated % NumberOfObjectsInRow;
            var xPosition = initialPosition.x + _shiftOverXAxis + xAxisOffset * column;
            var yPosition = initialPosition.y * _shiftOverYAxis + yAxisOffset;
            YStoredPosition = yPosition;
            XStoredPosition = xPosition;
            ZStoredPosition = initialPosition.z;
            return new Vector3(XStoredPosition, YStoredPosition, ZStoredPosition);
        }


        /// <summary>
        ///     Srt up color .
        /// </summary>
        /// <returns></returns>
        private static Color SetUpColor()
        {
            return new Color(Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f));
        }


        /// <summary>
        ///     Update shift over X.
        /// </summary>
        /// <param name="rend"></param>
        private void UpdateShiftOverXAxis(Renderer rend)
        {
            //Check all columns Covered.
            var currentColumn = _numberOfObjectAlreadyCreated % NumberOfObjectsInRow;
            if (NumberOfObjectsInRow - currentColumn == 1)
            {
                _shiftOverXAxis = 0f;
                return;
            }

            //Update the shift .
            //You are still in same row .
            _shiftOverXAxis += rend.bounds.size.x;
        }


        /// <summary>
        ///     Update shit Over Y .
        /// </summary>
        /// <param name="rend"></param>
        private void UpdateShiftOverYAxis(Renderer rend)
        {
            //Check all columns Covered.
            var currentColumn = _numberOfObjectAlreadyCreated % NumberOfObjectsInRow;
            if (NumberOfObjectsInRow - currentColumn == 1)
            {
                _shiftOverYAxis += _shiftOverYAxisOnProcess;
                _shiftOverYAxisOnProcess = 0f;
            }

            //Update the shift .
            var presentShiftOverY = rend.bounds.size.y;
            //Check Y change continuously .
            if (presentShiftOverY > _shiftOverYAxisOnProcess) _shiftOverYAxisOnProcess = presentShiftOverY;
        }
    }
}