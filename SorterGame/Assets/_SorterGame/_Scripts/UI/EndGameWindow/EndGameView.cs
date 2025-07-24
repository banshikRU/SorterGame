using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _SorterGame._Scripts.UI.EndGameWindow
{
    public class EndGameView : MonoBehaviour
    {
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private TMP_Text _winScoreText;
        [SerializeField] private Button _restartButton;

        private const string Scores = "Scores:";

        public void ShowWin(int score)
        {
            _winPanel.SetActive(true);
            _losePanel.SetActive(false);
            _winScoreText.text = Scores + score;
            gameObject.SetActive(true);
            _restartButton.gameObject.SetActive(true);
        }

        public void ShowLose()
        {
            _winPanel.SetActive(false);
            _losePanel.SetActive(true);
            gameObject.SetActive(true);
            _restartButton.gameObject.SetActive(true);
        }

        public void Init(System.Action onRestart)
        {
            _restartButton.onClick.AddListener(() => onRestart?.Invoke());
        }
        
        private void OnDestroy()
        {
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}