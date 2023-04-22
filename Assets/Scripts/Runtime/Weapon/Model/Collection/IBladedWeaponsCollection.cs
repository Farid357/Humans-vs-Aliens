namespace HumansVsAliens.Model
{
    public interface IBladedWeaponsCollection
    {
        IBladedWeapon Weapon { get; }
        
        void SwitchWeapon(IBladedWeapon weapon);
    }
}