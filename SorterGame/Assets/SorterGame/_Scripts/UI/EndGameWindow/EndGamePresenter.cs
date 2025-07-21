using UnityEngine.SceneManagement;

namespace SorterGame._Scripts.UI.EndGameWindow
{
    public class EndGamePresenter
    {
        private readonly EndGameView _view;
        private readonly EventBus.EventBus _eventBus;
        private int _score;

        public EndGamePresenter(EndGameView view, EventBus.EventBus eventBus)
        {
            _view = view;
            _eventBus = eventBus;
            
            _eventBus.OnCorrectDrop += () => _score++;
            _eventBus.OnGameEndStateChanged += OnGameEnd;
            
            view.Init(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
        
        private void OnGameEnd(bool isWin)
        {
            if (isWin)
            {
                _view.ShowWin(_score);
            }
            else
            {
                _view.ShowLose();
            }
        }
    }
}