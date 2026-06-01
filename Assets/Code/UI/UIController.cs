using System;
using UnityEngine;

namespace Code.UI
{
    public sealed class UIController
    {
        private StartLevelUI _startLevelUI;
        
        public event Action OnStartLevel
        {
            add {_startLevelUI.OnStart += value;}
            remove {_startLevelUI.OnStart -= value;}
        }

        public UIController(StartLevelUI startLevelUI)
        {
            _startLevelUI = startLevelUI;
        }

        public void StartLevel()
        {
            _startLevelUI.RefreshTimer();
            _startLevelUI.Show();
            _startLevelUI.StartTimer();
        }
    }
}