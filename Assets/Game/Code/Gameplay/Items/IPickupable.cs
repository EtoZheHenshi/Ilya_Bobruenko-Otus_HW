using Game.Code.Gameplay.Player;

namespace Game.Code.Gameplay.Items
{
    public interface IPickupable
    {
        public void Pickup(PlayerFacade playerFacade);
    }
}