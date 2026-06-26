using Game.Code.Gameplay.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class MainMenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuWndView _mainMenuWndView;
        
        public override void InstallBindings()
        {
            BindMainMenuInitializer();
            BindMainMenu();
        }

        private void BindMainMenuInitializer()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuSceneInitializer>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMainMenu()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuWndModel>()
                .AsSingle()
                .WithArguments(_mainMenuWndView);
        }
    }
}