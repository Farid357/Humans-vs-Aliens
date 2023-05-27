using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private CharacterAnimations _animations;

        public IHealthAnimations Animations => _animations;
        
        public void Attack()
        {
            _animations.PlayAttack();
        }

        public void SwitchWeapon()
        {
            //TODO Switch Weapon
        }
    }
}