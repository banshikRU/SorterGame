using System;
using _SorterGame._Scripts.Settings;
using Zenject;

namespace _SorterGame._Scripts.Core
{
    public class GameStatsService : IInitializable, IDisposable
    {
        public int Score { get; private set; }
        public int Health { get; private set; }
        
        public event Action<int> OnScoreChanged;
        public event Action<int> OnHealthChanged;
        
        private int _remainingShapes;

        private readonly EventBus.EventBus _eventBus;
        private readonly GameSettings _gameSettings;

        public GameStatsService(
            EventBus.EventBus eventBus,
            GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _eventBus = eventBus;
        }
        
        public void Initialize()
        {
            SubscribeEvents();
            
            Score = 0;
            Health = _gameSettings.PlayerHealth;
        }
        
        public void Dispose()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _eventBus.OnCorrectDrop += OnCorrect;
            _eventBus.OnWrongDrop += OnWrong;
            _eventBus.OnMissedFigure += OnMissed;
        }

        private void UnsubscribeEvents()
        {
            _eventBus.OnCorrectDrop -= OnCorrect;
            _eventBus.OnWrongDrop -= OnWrong;
            _eventBus.OnMissedFigure -= OnMissed;
        }

        public void SetRemainingShapes(int shapes)
        {
            _remainingShapes = shapes;
        }

        private void OnCorrect()
        {
            Score++;
            _remainingShapes--;
            OnScoreChanged?.Invoke(Score);
            CheckGameEnd();
        }

        private void OnWrong()
        {
            Health--;
            _remainingShapes--;
            OnHealthChanged?.Invoke(Health);
            CheckGameEnd();
        }

        private void OnMissed()
        {
            Health--;
            _remainingShapes--;
            OnHealthChanged?.Invoke(Health);
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            if (Health <= 0)
            {
                _eventBus.GameEnded(false);
            }
            else if (_remainingShapes <= 0)
            {
                _eventBus.GameEnded(true);
            }
        }
    }
}