using HumansVsAliens.Gameplay;
using HumansVsAliens.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.View
{
    public sealed class BladedWeaponsCollectionView : MonoBehaviour, IBladedWeaponsCollectionView
    {
        [SerializeField] private Image _weaponImage;
        [SerializeField] private TMP_Text _weaponName;

        private IBladedWeapon _lastWeapon;

        public void SwitchWeapon(IBladedWeapon weapon)
        {
            _lastWeapon?.View?.Disable();
            weapon.View.Enable();
            _lastWeapon = weapon;
            IBladedWeaponViewData viewData = weapon.View.Data;
            _weaponImage.sprite = viewData.Icon;
            _weaponName.text = viewData.Name;
        }
    }
}