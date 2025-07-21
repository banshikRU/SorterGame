using System;
using System.Threading;
using System.Threading.Tasks;
using SorterGame._Scripts.Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SorterGame._Scripts.Shapes
{
    public class ShapeSpawner: IInitializable, IDisposable
    {
        private readonly IFactory<ShapeType, Transform, ShapeView> _factory;
        private readonly GameSettings _settings;
        private readonly EventBus.EventBus _eventBus;
        private GameStatsService _gameStatsService;
        private CancellationTokenSource _cancellation;
        private Transform[] _spawnPoints;

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

            _eventBus.OnGameEndStateChanged += CancelSpawning;
        }
        
        public void Dispose()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
        
        public void Initialize()
        {
            StartSpawning();
        }
        private void StartSpawning()
        {
            Debug.Log("Initializing shape spawner");
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

                var type = (ShapeType)UnityEngine.Random.Range(0, 4);
                var line = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];
                var speed = UnityEngine.Random.Range(_settings.SpeedRange.x, _settings.SpeedRange.y);

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
