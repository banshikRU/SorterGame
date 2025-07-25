using _SorterGame._Scripts.Settings;
using _SorterGame._Scripts.Shapes;
using UnityEngine;
using Zenject;

namespace _SorterGame._Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private ShapeLibrary _shapeLibrary;
        
        public override void InstallBindings()
        {
            Container
                .Bind<GameSettings>()
                .FromInstance(_gameSettings)
                .AsSingle();
            
            Container
                .Bind<ShapeLibrary>()
                .FromInstance(_shapeLibrary)
                .AsSingle();
            
            Container
                .Bind<EventBus.EventBus>()
                .AsSingle();
        }
    }
}
