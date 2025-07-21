using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SorterGame._Scripts.UI.EndGameWindow
{
    public class EndGameView : MonoBehaviour
    {
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private TMP_Text _winScoreText;
        [SerializeField] private Button _restartButton;

        public void ShowWin(int score)
        {
            _winPanel.SetActive(true);
            _losePanel.SetActive(false);
            _winScoreText.text = $"Очки: {score}";
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

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Init(System.Action onRestart)
        {
            _restartButton.onClick.AddListener(() => onRestart?.Invoke());
        }
    }
}