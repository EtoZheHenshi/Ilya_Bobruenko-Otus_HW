using System;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.UI.HUD
{
    public sealed class HUDModel : IDisposable
    {
        private readonly HUDView _hudView;
        private readonly Player _player;

        public HUDModel(HUDView hudView, Player player)
        {
            _hudView = hudView;
            _player = player;
            
            player.OnLvlUp += UpdateLvlCount;
            player.OnTakeDamage += UpdateHpCount;
            player.OnHeal += UpdateHpCount;
            hudView.OnDeath += Dispose;
            
            UpdateHpCount();
            UpdateLvlCount();
        }
        
        public void Dispose()
        {
            _player.OnLvlUp -= UpdateLvlCount;
            _player.OnTakeDamage -= UpdateHpCount;
            _player.OnHeal -= UpdateHpCount;
            
            _hudView.OnDeath += Dispose;
        }

        private void UpdateHpCount()
        {
            _hudView.HpCount.text = Mathf.Ceil(_player.CurrentHP).ToString();
        }

        private void UpdateLvlCount()
        {
            _hudView.LvlCount.text = _player.CurrentLvl.ToString();
        }
    }
}