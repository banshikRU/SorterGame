using UnityEngine;

namespace SorterGame._Scripts.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public Vector2Int ShapeCountRange;
        public Vector2 SpawnDelayRange;
        public Vector2 SpeedRange;
        public int PlayerHealth;
    }
}
