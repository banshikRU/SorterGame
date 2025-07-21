using UnityEngine;
using Zenject;

namespace SorterGame._Scripts.Shapes
{
    public class ShapeDragSystem : ITickable
    {
        private IShapeDraggable _dragged;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.OverlapPoint(mousePos);

                if (hit != null && hit.TryGetComponent<IShapeDraggable>(out var draggable))
                {
                    _dragged = draggable;
                    _dragged.StartDrag();
                }
            }

            if (Input.GetMouseButton(0) && _dragged != null)
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                _dragged.DragTo(mousePos);
            }

            if (Input.GetMouseButtonUp(0) && _dragged != null)
            {
                _dragged.StopDrag();
                _dragged = null;
            }
        }
    }
}