using TMPro;
using UnityEngine;

namespace SorterGame._Scripts.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}