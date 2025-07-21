using TMPro;
using UnityEngine;

namespace SorterGame._Scripts.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;

        public void SetHealth(int health)
        {
            healthText.text = health.ToString();
        }

    }
}