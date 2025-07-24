using UnityEngine;

namespace _SorterGame._Scripts.Shapes
{
    public class ShapeView : MonoBehaviour, IShapeDraggable
    {
        public ShapeType ShapeType { get; private set; }

        private Vector3 _startPos;
        private float _speed;
        private bool _dragging;

        public void Init(ShapeType shapeType, float speed)
        {
            ShapeType = shapeType;
            _speed = speed;
            _startPos = transform.position;
        }

        public void ResetToInitial()
        {
            transform.position = _startPos;
            _dragging = false;
        }

        public void Update()
        {
            if (!_dragging)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }

        public void StartDrag()
        {
            _startPos = transform.position;
            _dragging = true;
        }

        public void DragTo(Vector3 worldPosition)
        {
            transform.position = worldPosition;
        }
    }
}