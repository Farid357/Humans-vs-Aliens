using HumansVsAliens.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.Gameplay
{
    public sealed class BladedWeaponsCollectionView : MonoBehaviour, IBladedWeaponsCollectionView
    {
        [SerializeField] private Image _weaponImage;
        [SerializeField] private TMP_Text _weaponName;
        
        public void SwitchWeapon(IBladedWeapon weapon)
        {
            IBladedWeaponViewData viewData = weapon.View.Data;
            _weaponImage.sprite = viewData.Icon;
            _weaponName.text = viewData.Name;
        }
    }
}