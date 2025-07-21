using System;
using SorterGame._Scripts.Settings;

namespace SorterGame._Scripts
{
    public class GameStatsService
    {
        public int Score { get; private set; }
        public int Health { get; private set; }
        public int RemainingShapes { get; private set; }

        public event Action<int> OnScoreChanged;
        public event Action<int> OnHealthChanged;

        private readonly EventBus.EventBus _eventBus;

        public GameStatsService(EventBus.EventBus eventBus,GameSettings gameSettings)
        {
            _eventBus = eventBus;
            
            _eventBus.OnCorrectDrop += OnCorrect;
            _eventBus.OnWrongDrop += OnWrong;
            _eventBus.OnMissedFigure += OnMissed;

            Score = 0;
            Health = gameSettings.PlayerHealth;
        }

        public void SetRemainingShapes(int shapes)
        {
            RemainingShapes = shapes;
        }

        private void OnCorrect()
        {
            Score++;
            RemainingShapes--;
            OnScoreChanged?.Invoke(Score);
            CheckGameEnd();
        }

        private void OnWrong()
        {
            Health--;
            RemainingShapes--;
            OnHealthChanged?.Invoke(Health);
            CheckGameEnd();
        }

        private void OnMissed()
        {
            Health--;
            RemainingShapes--;
            OnHealthChanged?.Invoke(Health);
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            if (Health <= 0)
            {
                _eventBus.GameEnded(false);
            }
            else if (RemainingShapes <= 0)
            {
                _eventBus.GameEnded(true);
            }
        }
    }
}