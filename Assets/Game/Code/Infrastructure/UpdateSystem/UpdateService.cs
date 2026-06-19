using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.UpdateSystem
{
    public sealed class UpdateService : ITickable, IFixedTickable, ILateTickable
    {
        private readonly List<IUpdatable> _tickables;
        private readonly List<IFixedUpdatable> _fixedTickables;
        private readonly List<ILateUpdatable> _lateTickables;

        public UpdateService()
        {
            _tickables = new List<IUpdatable>();
            _fixedTickables = new List<IFixedUpdatable>();
            _lateTickables = new List<ILateUpdatable>();
        }

        public void Tick()
        {
            for (int i = 0; i < _tickables.Count; i++)
            {
                _tickables[i]?.Tick(Time.deltaTime);
            }
        }

        public void FixedTick()
        {
            for (int i = 0; i < _fixedTickables.Count; i++)
            {
                _fixedTickables[i]?.FixedTick(Time.fixedDeltaTime);
            }
        }

        public void LateTick()
        {
            for (int i = 0; i < _lateTickables.Count; i++)
            {
                _lateTickables[i]?.LateTick(Time.deltaTime);
            }
        }

        public void Register(IUpdatable updatable)
        {
            if (_tickables.Contains(updatable)) 
                return;
            
            _tickables.Add(updatable);
        }

        public void Register(IFixedUpdatable fixedUpdatable)
        {
            if (_fixedTickables.Contains(fixedUpdatable)) 
                return;

            _fixedTickables.Add(fixedUpdatable);
        }

        public void Register(ILateUpdatable lateUpdatable)
        {
            if (_lateTickables.Contains(lateUpdatable)) 
                return;

            _lateTickables.Add(lateUpdatable);
        }
        
        public void Unregister(IUpdatable updatable)
        {
            _tickables.Remove(updatable);
        }

        public void Unregister(IFixedUpdatable fixedUpdatable)
        {
            _fixedTickables.Remove(fixedUpdatable);
        }

        public void Unregister(ILateUpdatable lateUpdatable)
        {
            _lateTickables.Remove(lateUpdatable);
        }
    }
}