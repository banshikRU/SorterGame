using System;
using _SorterGame._Scripts.Core;
using _SorterGame._Scripts.EventBus;
using Zenject;

namespace SorterGame._Scripts.UI.Health
{
    public class HealthPresenter : IInitializable, IDisposable
    {
        private int _health;
        
        private readonly HealthView _view;
        private readonly EventBus _eventBus;
        private readonly GameStatsService _gameStatsService;

        public HealthPresenter(
            HealthView view,
            GameStatsService gameStatsService)
        {
            _gameStatsService = gameStatsService;
            _view = view;
        }

        public void Initialize()
        {
            _view.SetHealth(_gameStatsService.Health);
            _gameStatsService.OnHealthChanged += _view.SetHealth;
        }

        public void Dispose()
        {
            _gameStatsService.OnHealthChanged -= _view.SetHealth;
        }
    }
}