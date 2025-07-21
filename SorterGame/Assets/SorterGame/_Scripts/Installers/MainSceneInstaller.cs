using SorterGame._Scripts.Settings;
using SorterGame._Scripts.Shapes;
using UnityEngine;
using Zenject;

namespace SorterGame._Scripts.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField]private Transform[] spawnPoints;

        public override void InstallBindings()
        {
            Container
                .BindIFactory<ShapeType, Transform, ShapeView>()
                .To<ShapeView>()
                .FromFactory<ShapeFactory>();
            
            Container
                .BindInterfacesAndSelfTo<ShapeDragSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ShapeSpawner>()
                .AsSingle()
                .WithArguments(spawnPoints)
                .NonLazy();
        }
    }
}