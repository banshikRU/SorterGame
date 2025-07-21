using SorterGame._Scripts.Shapes;
using UnityEngine;
using Zenject;

namespace SorterGame._Scripts.SceneObjects
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathZone : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;

        [Inject]
        public void Inject(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<ShapeView>(out _))
            {
                _eventBus.FigureMissed();
                Destroy(other.gameObject);
            }
        }
    }
}