using _SorterGame._Scripts.FXSystem;
using _SorterGame._Scripts.Shapes;
using UnityEngine;
using Zenject;

namespace _SorterGame._Scripts.SceneObjects
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathZone : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;
        private ExplosionService _explosionService;

        [Inject]
        public void Inject(
            EventBus.EventBus eventBus,
            ExplosionService explosionService)
        {
            _explosionService = explosionService;
            _eventBus = eventBus;
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<ShapeView>(out _))
            {
                _eventBus.FigureMissed();
                _explosionService.CreateExplosionAt(other.transform.position);
                Destroy(other.gameObject);
            }
        }
    }
}