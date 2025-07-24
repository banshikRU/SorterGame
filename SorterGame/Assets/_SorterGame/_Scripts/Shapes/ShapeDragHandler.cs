using _SorterGame._Scripts.FXSystem;
using _SorterGame._Scripts.Settings;
using _SorterGame._Scripts.Slots;
using UnityEngine;
using Zenject;

namespace _SorterGame._Scripts.Shapes
{
    public class ShapeDragHandler : ITickable
    {
        private IShapeDraggable _dragged;
        
        private readonly Camera _camera;
        private readonly EventBus.EventBus _eventBus;
        private readonly ExplosionService _explosionService;
        private readonly LayerMask _slotLayer;

        public ShapeDragHandler(
            EventBus.EventBus eventBus,
            ExplosionService explosionService,
            GameSettings gameSettings)
        {
            _camera = Camera.main;
            _eventBus = eventBus;
            _explosionService = explosionService;
            _slotLayer = gameSettings.SlotLayerMask;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.OverlapPoint(worldPos);

                if (hit != null && hit.TryGetComponent<IShapeDraggable>(out var draggable))
                {
                    _dragged = draggable;
                    _dragged.StartDrag();
                }
            }

            if (Input.GetMouseButton(0) && _dragged != null)
            {
                var worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
                worldPos.z = 0;
                _dragged.DragTo(worldPos);
            }

            if (Input.GetMouseButtonUp(0) && _dragged != null)
            {
                HandleDrop(_dragged as MonoBehaviour);
                _dragged = null;
            }
        }

        private void HandleDrop(MonoBehaviour draggedMono)
        {
            var shapeView = draggedMono.GetComponent<ShapeView>();
            var worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            var hit = Physics2D.OverlapPoint(worldPos, _slotLayer);

            if (hit != null && hit.TryGetComponent<SlotView>(out var slot))
            {
                if (slot.IsCorrect(shapeView.ShapeType))
                {
                    _eventBus.FigureDroppedCorrectly();
                }
                else
                {
                    _explosionService.CreateExplosionAt(shapeView.transform.position);
                    _eventBus.FigureDroppedWrongly();
                }
            }
            else
            {
                shapeView.ResetToInitial();
                return;
            }

            Object.Destroy(shapeView.gameObject);
        }
    }
}
