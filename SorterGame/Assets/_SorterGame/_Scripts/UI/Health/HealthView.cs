using TMPro;
using UnityEngine;

namespace SorterGame._Scripts.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Animator _animator;
        
        private const string HealthAnimation = "HealthChange";
        
        public void SetHealth(int health)
        {
            _animator.Play(HealthAnimation);
            _healthText.text = health.ToString();
        }

    }
}