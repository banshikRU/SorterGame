﻿using _SorterGame._Scripts.Core;
using _SorterGame._Scripts.UI.EndGameWindow;
using _SorterGame._Scripts.UI.Score;
using SorterGame._Scripts.UI;
using SorterGame._Scripts.UI.Health;
using UnityEngine;
using Zenject;

namespace _SorterGame._Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private EndGameView _endGameView;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameStatsService>()
                .AsSingle();
            
            Container
                .Bind<ScoreView>()
                .FromInstance(_scoreView)
                .AsSingle();
            
            Container
                .Bind<HealthView>()
                .FromInstance(_healthView)
                .AsSingle();
            
            Container
                .Bind<EndGameView>()
                .FromInstance(_endGameView)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ScorePresenter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<HealthPresenter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EndGamePresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}