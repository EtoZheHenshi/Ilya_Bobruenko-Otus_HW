using System.Collections.Generic;

namespace Game.Code.Infrastructure.UpdateSystem
{
    public sealed class UpdateService
    {
        private List<ITickable> _tickables;
        private List<IFixedTickable> _fixedTickables;
        private List<ILateTickable> _lateTickables;

        public UpdateService()
        {
            _tickables = new List<ITickable>();
            _fixedTickables = new List<IFixedTickable>();
            _lateTickables = new List<ILateTickable>();
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _tickables.Count; i++)
            {
                _tickables[i]?.Tick(deltaTime);
            }
        }

        public void FixedTick(float fixedDeltaTime)
        {
            for (int i = 0; i < _fixedTickables.Count; i++)
            {
                _fixedTickables[i]?.FixedTick(fixedDeltaTime);
            }
        }

        public void LateTick(float deltaTime)
        {
            for (int i = 0; i < _lateTickables.Count; i++)
            {
                _lateTickables[i]?.LateTick(deltaTime);
            }
        }

        public void Register(ITickable tickable)
        {
            _tickables.Add(tickable);
        }

        public void Register(IFixedTickable fixedTickable)
        {
            _fixedTickables.Add(fixedTickable);
        }

        public void Register(ILateTickable lateTickable)
        {
            _lateTickables.Add(lateTickable);
        }
        
        public void Remove(ITickable tickable)
        {
            _tickables.Remove(tickable);
        }

        public void Remove(IFixedTickable fixedTickable)
        {
            _fixedTickables.Remove(fixedTickable);
        }

        public void Remove(ILateTickable lateTickable)
        {
            _lateTickables.Remove(lateTickable);
        }
    }
}