using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            if (BootstrapInitializer.CheckBootstrapStatus(SceneManager.GetActiveScene()) == false) return;

            BindGameplaySceneInitializer();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindGameplaySceneInitializer()
        {
            Container
                .BindInterfacesAndSelfTo<GameplaySceneInitializer>()
                .AsSingle();
        }
    }
}