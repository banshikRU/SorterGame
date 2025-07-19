using System;
using UnityEngine;

namespace SorterGame._Scripts.Shapes
{
    [CreateAssetMenu(fileName = "ShapeLibrary", menuName = "Settings/ShapeLibrary")]
    public class ShapeLibrary : ScriptableObject
    {
        [SerializeField] private ShapeEntry[] shapes;
        
        [Serializable]
        private struct ShapeEntry
        {
            public ShapeType type;
            public ShapeView prefab;
        }
        
        public ShapeView GetPrefab(ShapeType type)
        {
            foreach (var shape in shapes)
            {
                if (shape.type == type) return shape.prefab;
            }
            
            return null;
        }
    }
}