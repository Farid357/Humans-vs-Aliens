using System;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class EnemyWeaponAim : IWeaponAim
    {
        private readonly ICharacterSearcher _characterSearcher;
        private readonly Transform _transform;

        public EnemyWeaponAim(Transform transform, float radiusToSeeCharacter)
        {
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            _characterSearcher = new CharacterSearcher(_transform, radiusToSeeCharacter);
        }

        public Vector3 ShootDirection
        {
            get
            {
                _characterSearcher.Search();

                if (_characterSearcher.HasFoundCharacter)
                    return (_characterSearcher.FoundCharacter.Position() - _transform.position).normalized;

                throw new InvalidOperationException($"Aim hasn't found characters in radius!");
            }
        }
    }
}