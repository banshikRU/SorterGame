using TMPro;
using UnityEngine;

namespace SorterGame._Scripts.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}