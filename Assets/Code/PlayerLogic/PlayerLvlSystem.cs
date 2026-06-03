using System;

namespace Code.PlayerLogic
{
    public sealed class PlayerLvlSystem
    {
        public event Action OnLvlUp;
        
        private readonly int[] _lvlExpTable;
        private readonly int _expIncreaseForHighLvl;
        private readonly int _maxLvl;
        
        private int _currentExp;
        private int _expForNextLvl;
        private int _currentLvl;
        
        public int CurrentLvl => _currentLvl;

        public PlayerLvlSystem(PlayerLvlExpTableSO playerLvlExpTable)
        {
            _lvlExpTable = playerLvlExpTable.LvlExpTable;
            _expIncreaseForHighLvl = playerLvlExpTable.ExpIncreaseForHighLvl;
            _maxLvl = playerLvlExpTable.MaxLvl;
            _currentExp = 0;
            _expForNextLvl = _lvlExpTable[0];
            _currentLvl = 1;
        }
        
        public void UpdateTick()
        {
            if (_currentLvl >= _maxLvl) return;
            
            CheckLvlUp();
        }

        public void AddExp(int exp)
        {
            _currentExp += exp;
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
            
            OnLvlUp?.Invoke();
        }
        
        private void CheckLvlUp()
        {
            if (_currentExp >= _expForNextLvl)
            {
                LvlUp();
            }
        }
    }
}