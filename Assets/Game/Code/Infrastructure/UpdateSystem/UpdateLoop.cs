using System;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.UpdateSystem
{
    public sealed class UpdateLoop : MonoBehaviour
    {
        private UpdateService _updateService;
        
        [Inject]
        public void Construct(UpdateService updateService)
        {
            _updateService = updateService;
        }

        private void Update()
        {
            _updateService.Tick(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _updateService.FixedTick(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            _updateService.LateTick(Time.deltaTime);
        }
    }
}