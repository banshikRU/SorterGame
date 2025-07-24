using System;
using UnityEngine;

namespace _SorterGame._Scripts.Shapes
{
    [CreateAssetMenu(fileName = "ShapeLibrary", menuName = "Settings/ShapeLibrary")]
    public class ShapeLibrary : ScriptableObject
    {
        [SerializeField] private ShapeEntry[] _shapes;
        
        [Serializable]
        private struct ShapeEntry
        {
            public ShapeType type;
            public ShapeView prefab;
        }
        
        public ShapeView GetPrefab(ShapeType type)
        {
            foreach (var shape in _shapes)
            {
                if (shape.type == type) return shape.prefab;
            }
            
            throw new InvalidOperationException
                ($"Prefab for ShapeType {type} not found in ShapeLibrary.");
        }
    }
}