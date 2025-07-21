using UnityEngine;

namespace SorterGame._Scripts.Shapes
{
    public class ShapeView : MonoBehaviour
    {
        public ShapeType ShapeType { get; private set; }
        public float Speed { get; private set; }

        private bool _dragging;

        public void Init(ShapeType shapeType, float speed)
        {
            ShapeType = shapeType;
            Speed = speed;
        }

        public void SetDragging(bool dragging)
        {
            _dragging = dragging;
        }

        private void Update()
        {
            if (!_dragging)
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }
}