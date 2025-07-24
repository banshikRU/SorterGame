using System;
using _SorterGame._Scripts.Core;
using UnityEngine.SceneManagement;
using Zenject;

namespace _SorterGame._Scripts.UI.EndGameWindow
{
    public class EndGamePresenter : IInitializable, IDisposable
    {
        private readonly EndGameView _view;
        private readonly EventBus.EventBus _eventBus;
        private readonly GameStatsService _gameStatsService;

        public EndGamePresenter(
            EndGameView view,
            EventBus.EventBus eventBus,
            GameStatsService gameStatsService)
        {
            _gameStatsService = gameStatsService;
            _view = view;
            _eventBus = eventBus;
        }
        
        public void Initialize()
        {
            _eventBus.OnGameEnded += OnGameEnd;
            
            _view.Init(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
        
        public void Dispose()
        {
            _eventBus.OnGameEnded -= OnGameEnd;
        }
        
        private void OnGameEnd(bool isWin)
        {
            if (isWin)
            {
                _view.ShowWin(_gameStatsService.Score);
            }
            else
            {
                _view.ShowLose();
            }
        }
    }
}