using Game.Code.Gameplay.Player.PlayerSO;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Player.PlayerComponents
{
    public sealed class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private PlayerLevelExpTableSO _playerLevelExpTable;
        
        private EventBusService _eventBus;
        
        private int[] _lvlExpTable;
        private int _expIncreaseForHighLvl;
        private int _maxLvl;
        
        private int _currentExp;
        private int _expForNextLvl;
        private int _currentLvl;
        
        public int CurrentLevel => _currentLvl;

        [Inject]
        public void Construct(EventBusService eventBus)
        {
            _eventBus = eventBus;
            
            _lvlExpTable = _playerLevelExpTable.LvlExpTable;
            _expIncreaseForHighLvl = _playerLevelExpTable.ExpIncreaseForHighLvl;
            _maxLvl = _playerLevelExpTable.MaxLvl;
            _currentExp = 0;
            _expForNextLvl = _lvlExpTable[0];
            _currentLvl = 1;
        }

        public void AddExp(int exp)
        {
            _currentExp += exp;

            if (_currentLvl >= _maxLvl) return;
            
            CheckLvlUp();
        }
        
        private void LvlUp()
        {
            _currentLvl++;
            _currentExp -= _expForNextLvl;
            if (_currentLvl > _lvlExpTable.Length)
            {
                _expForNextLvl = _lvlExpTable[^1] + _expIncreaseForHighLvl * (_currentLvl - _lvlExpTable.Length);
            }
            else
            {
                _expForNextLvl = _lvlExpTable[_currentLvl - 1];
            }
            
            _eventBus.Publish(new PlayerLevelUpEvent(_currentLvl));
        }
        
        private void CheckLvlUp()
        {
            if (_currentExp < _expForNextLvl) 
                return;
            
            while (_currentExp >= _expForNextLvl && _currentLvl < _maxLvl)
            {
                LvlUp();
            }
        }
    }
}