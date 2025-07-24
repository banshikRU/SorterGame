using System;
using _SorterGame._Scripts.Core;
using SorterGame._Scripts.UI;
using Zenject;

namespace _SorterGame._Scripts.UI.Score
{
    public class ScorePresenter: IInitializable, IDisposable
    {
        private readonly ScoreView _view;
        private readonly GameStatsService _gameStatsService;

        public ScorePresenter(ScoreView view,
            GameStatsService gameStatsService)
        {
            _view = view;
            _gameStatsService = gameStatsService;
        }

        public void Initialize()
        {
            _view.SetScore(_gameStatsService.Score);
        
            _gameStatsService.OnScoreChanged += SetScore;
        }
    
        public void Dispose()
        {
            _gameStatsService.OnScoreChanged -= SetScore;
        }

        private void SetScore(int score)
        {
            _view.SetScore(score);
        }
    }
}