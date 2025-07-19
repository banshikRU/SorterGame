using SorterGame._Scripts.Settings;
using SorterGame._Scripts.Shapes;
using UnityEngine;
using Zenject;

namespace SorterGame._Scripts.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private ShapeLibrary _shapeLibrary;

        public override void InstallBindings()
        {
           // Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
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
            
            Container
                .BindIFactory<ShapeType, Transform, ShapeView>()
                .To<ShapeView>()
                .FromFactory<ShapeFactory>();
        }
    }
}