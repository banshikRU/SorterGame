using _SorterGame._Scripts.Settings;
using UnityEngine;
using Zenject;

namespace _SorterGame._Scripts.FXSystem
{
    public class ExplosionService
    {
        private readonly GameSettings _gameSettings;
        private readonly DiContainer _container;

        public ExplosionService(
            GameSettings gameSettings,
            DiContainer container)
        {
            _gameSettings  = gameSettings;
            _container = container;
        }

        public void CreateExplosionAt(Vector3 worldPosition)
        {
            _container.InstantiatePrefab(
                _gameSettings.ExplosionPrefab,
                worldPosition, Quaternion.identity,
                null);
        }
    }
}