using System.Reflection;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class BulletHitContext
    {
        public bool IsHitLastTarget { get; set; }
        public bool ActivateBaseHit { get; set; }
        public bool ActivateDeath { get; set; }
        public bool IsItDuplicate { get; set; }

        public void Reset()
        {
            IsHitLastTarget = true;
            ActivateBaseHit = true;
            ActivateDeath = true;
        }
    }
}