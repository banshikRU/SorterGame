using UnityEngine;
using SorterGame._Scripts.EventBus;
using SorterGame._Scripts.Shapes;
using SorterGame._Scripts.Slots;
using Zenject;

[RequireComponent(typeof(ShapeView))]
public class ShapeDragHandler : MonoBehaviour, IShapeDraggable
{
    [SerializeField] private LayerMask slotLayerMask;
    
    private ShapeView _view;
    private EventBus _eventBus;
    private Vector3 _startPos;

    [Inject]
    public void Construct(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    private void Awake()
    {
        _view = GetComponent<ShapeView>();
        _startPos = transform.position;
    }

    public void StartDrag()
    {
        _view.SetDragging(true);
        _startPos = transform.position;
    }

    public void DragTo(Vector3 worldPos)
    {
        transform.position = worldPos;
    }

    public void StopDrag()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        Collider2D hit = Physics2D.OverlapPoint(worldPos,slotLayerMask);
        if (hit && hit.TryGetComponent<SlotView>(out var slot))
        {
            if (slot.IsCorrect(_view.ShapeType))
            {
                _eventBus.FigureDroppedCorrectly();
                Destroy(gameObject);
            }
            else
            {
                _eventBus.FigureDroppedWrongly();
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = _startPos;
            _view.SetDragging(false);
        }
    }
}