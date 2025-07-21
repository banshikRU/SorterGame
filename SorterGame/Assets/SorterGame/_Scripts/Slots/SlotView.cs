using SorterGame._Scripts.Shapes;
using UnityEngine;

namespace SorterGame._Scripts.Slots
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private ShapeType _type;

        public bool IsCorrect(ShapeType type)
        {
            return _type == type;
        }
    }
}