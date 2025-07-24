using System;
using System.Threading;
using System.Threading.Tasks;
using _SorterGame._Scripts.Core;
using _SorterGame._Scripts.Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _SorterGame._Scripts.Shapes
{
    public class ShapeSpawner: IInitializable, IDisposable
    {
        private CancellationTokenSource _cancellation;
        
        private readonly IFactory<ShapeType, Transform, ShapeView> _factory;
        private readonly GameSettings _settings;
        private readonly EventBus.EventBus _eventBus;
        private readonly GameStatsService _gameStatsService;
        private readonly Transform[] _spawnPoints;

        public ShapeSpawner(
            IFactory<ShapeType, Transform, ShapeView> factory,
            GameSettings settings,
            EventBus.EventBus eventBus,
            Transform[] spawnPoints,
            GameStatsService gameStatsService
            )
        {
            _gameStatsService = gameStatsService;
            _factory = factory;
            _settings = settings;
            _eventBus = eventBus;
            _spawnPoints = spawnPoints;
        }
        
        public void Initialize()
        {
            _eventBus.OnGameEnded += CancelSpawning;
            
            StartSpawning();
        }
        
        public void Dispose()
        {
            _eventBus.OnGameEnded -= CancelSpawning;
            
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
        
        private void StartSpawning()
        {
            _cancellation = new CancellationTokenSource();
            _ = SpawnAsync(_cancellation.Token);
        }

        private async Task SpawnAsync(CancellationToken token)
        {
            int total = Random.Range(_settings.ShapeCountRange.x, _settings.ShapeCountRange.y + 1);
            
            _gameStatsService.SetRemainingShapes(total);

            for (int i = 0; i < total; i++)
            {
                float delay = Random.Range(_settings.SpawnDelayRange.x, _settings.SpawnDelayRange.y);
                
                try
                {
                    await Task.Delay((int)(delay * 1000), token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                if (!Application.isPlaying || token.IsCancellationRequested)
                    break;

                var type = (ShapeType)Random.Range(0, 4);
                var line = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                var speed = Random.Range(_settings.SpeedRange.x, _settings.SpeedRange.y);

                var shape = _factory.Create(type, line);
                shape.Init(type, speed);
            }
        }

        private void CancelSpawning(bool isWin)
        {
            _cancellation?.Cancel();
        }
    }
}
