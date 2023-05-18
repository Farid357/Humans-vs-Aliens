namespace HumansVsAliens.Gameplay
{
    public interface IBladedWeaponsCollection
    {
        IBladedWeapon Weapon { get; }
        
        void SwitchWeapon(IBladedWeapon weapon);
    }
}