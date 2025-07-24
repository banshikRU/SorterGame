using UnityEngine;

namespace _SorterGame._Scripts.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public Vector2Int ShapeCountRange => _shapeCountRange;
        public Vector2 SpawnDelayRange => _spawnDelayRange;
        public Vector2 SpeedRange => _speedRange;
        public int PlayerHealth => _playerHealth;
        public GameObject ExplosionPrefab => _explosionPrefab;
        public LayerMask SlotLayerMask => _slotLayerMask;

        [SerializeField] private Vector2Int _shapeCountRange;
        [SerializeField] private Vector2 _spawnDelayRange;
        [SerializeField] private Vector2 _speedRange;
        [SerializeField] private int _playerHealth;
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private LayerMask _slotLayerMask;
    }
}
