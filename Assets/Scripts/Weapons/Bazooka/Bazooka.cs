namespace Weapons.Bazooka
{
    public class Bazooka : Weapon
    {
        private const string NAME = "Bazooka";

        protected override void Start()
        {
            base.Start();
            weaponName = NAME;
        }
    }
}