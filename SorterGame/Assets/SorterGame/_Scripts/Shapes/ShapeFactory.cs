using UnityEngine;
using Zenject;

namespace SorterGame._Scripts.Shapes
{
    public class ShapeFactory : IFactory<ShapeType, Transform, ShapeView>
    {
        private readonly DiContainer _container;
        private readonly ShapeLibrary _library;

        public ShapeFactory(DiContainer container, ShapeLibrary library)
        {
            _container = container;
            _library = library;
        }

        public ShapeView Create(ShapeType type, Transform parent)
        {
            var prefab = _library.GetPrefab(type);
            return _container.InstantiatePrefabForComponent<ShapeView>(prefab, parent);
        }
    }
}