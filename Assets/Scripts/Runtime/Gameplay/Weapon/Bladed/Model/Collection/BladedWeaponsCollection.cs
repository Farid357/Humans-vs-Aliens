using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class BladedWeaponsCollection : IBladedWeaponsCollection
    {
        private readonly IBladedWeaponsCollectionView _view;

        public BladedWeaponsCollection(IBladedWeapon weapon, IBladedWeaponsCollectionView view)
        {
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.SwitchWeapon(Weapon);
        }

        public IBladedWeapon Weapon { get; private set; }
        
        public void SwitchWeapon(IBladedWeapon weapon)
        {
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view.SwitchWeapon(Weapon);
        }
    }
}