using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInitializer : IInitializable
    {
        public bool IsInitialized { get; private set; }
        
        public void Initialize()
        {
            IsInitialized = true;

            Debug.Log($"{this.GetType()} installed");
        }
    }
}