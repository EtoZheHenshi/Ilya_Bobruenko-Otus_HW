using System;
using System.Diagnostics.CodeAnalysis;
using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.UI.HUD.HP
{
    [SuppressMessage("ReSharper", "AccessToStaticMemberViaDerivedType")]
    public sealed class HpGroupModel : IDisposable
    {
        private readonly HpGroupView _view;
        private readonly PlayerRegistry _playerRegistry;
        
        private HpIconModel[] _hpIcons;

        public HpGroupModel(HpGroupView view, PlayerRegistry playerRegistry)
        {
            _view = view;
            _playerRegistry = playerRegistry;
        }

        public void Initialize()
        {
            _hpIcons = new HpIconModel[(int)_playerRegistry.Player.PlayerStats.MaxHealth.MaxValue];
            _playerRegistry.Player.PlayerHealth.OnTakeDamage += UpdateHpIcon;
            _playerRegistry.Player.PlayerHealth.OnHeal += UpdateHpIcon;
            _playerRegistry.Player.PlayerHealth.OnDeath += UpdateHpIcon;

            int startHp = (int)_playerRegistry.Damageable.MaxHealth.CurrentValue;
            for (int i = 0; i < startHp; i++)
            {
                AddHpIcon(i);
            }
        }

        public void AddHpIcon(int iconId)
        {
            HpIconView obj = GameObject.Instantiate(_view.HpIconPrefab, _view.transform);
            HpIconModel icon = new HpIconModel(obj);
            _hpIcons[iconId] = icon;
            UpdateHpIcon();
        }

        private void UpdateHpIcon()
        {
            int fillHp = (int)_playerRegistry.Damageable.CurrentHealth;

            for (int i = 0; i < _hpIcons.Length; i++)
            {
                if(_hpIcons[i] == null)
                    break;

                if (i < fillHp)
                {
                    _hpIcons[i].SetHpFull();
                }
                else
                {
                    _hpIcons[i].SetHpEmpty();
                }
            }
        }

        public void Dispose()
        {
            _playerRegistry.Player.PlayerHealth.OnTakeDamage -= UpdateHpIcon;
            _playerRegistry.Player.PlayerHealth.OnHeal -= UpdateHpIcon;
            _playerRegistry.Player.PlayerHealth.OnDeath -= UpdateHpIcon;
        }
    }
}