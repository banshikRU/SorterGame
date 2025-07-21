
using UnityEngine;

namespace SorterGame._Scripts.Shapes
{
    public interface IShapeDraggable
    {
        void StartDrag();
        void DragTo(Vector3 worldPosition);
        void StopDrag();
    }
}