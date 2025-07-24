using _SorterGame._Scripts.FXSystem;
using _SorterGame._Scripts.Shapes;
using UnityEngine;
using Zenject;

namespace _SorterGame._Scripts.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField]private Transform[] _spawnPoints;

        public override void InstallBindings()
        {
            Container
                .Bind<ExplosionService>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindIFactory<ShapeType, Transform, ShapeView>()
                .To<ShapeView>()
                .FromFactory<ShapeFactory>();
            
            Container
                .BindInterfacesAndSelfTo<ShapeDragHandler>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ShapeSpawner>()
                .AsSingle()
                .WithArguments(_spawnPoints)
                .NonLazy();
        }
    }
}