using Game.Code.Gameplay.UI.HUD.HP;
using Game.Code.Gameplay.UI.HUD.Level;

namespace Game.Code.Gameplay.UI.HUD
{
    public sealed class HudModel
    {
        private readonly HpGroupModel _hpGroupModel;
        private readonly LevelTextModel _levelTextModel;

        public HudModel(HpGroupModel hpGroupModel, LevelTextModel levelTextModel)
        {
            _hpGroupModel = hpGroupModel;
            _levelTextModel = levelTextModel;
        }

        public void Initialize()
        {
            _hpGroupModel.Initialize();
            _levelTextModel.Initialize();
        }
    }
}