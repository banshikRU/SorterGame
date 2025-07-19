using UnityEngine;

namespace SorterGame._Scripts.Shapes
{
    public class ShapeView : MonoBehaviour
    {
        public ShapeType ShapeType { get; private set; }

        public void Init(ShapeType shapeType, float speed)
        {
            ShapeType = shapeType;
        }
    }
}
