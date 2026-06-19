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
            _tickables.Add(updatable);
        }

        public void Register(IFixedUpdatable fixedUpdatable)
        {
            _fixedTickables.Add(fixedUpdatable);
        }

        public void Register(ILateUpdatable lateUpdatable)
        {
            _lateTickables.Add(lateUpdatable);
        }
        
        public void Remove(IUpdatable updatable)
        {
            _tickables.Remove(updatable);
        }

        public void Remove(IFixedUpdatable fixedUpdatable)
        {
            _fixedTickables.Remove(fixedUpdatable);
        }

        public void Remove(ILateUpdatable lateUpdatable)
        {
            _lateTickables.Remove(lateUpdatable);
        }
    }
}