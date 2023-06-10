using System;
using System.Linq;
using HumansVsAliens.Gameplay;
using UnityEngine;

namespace HumansVsAliens.Tools
{
    public static class CharacterExtensions
    {
        private static readonly Collider[] _colliders = new Collider[50];
        private static IChest _chest;

        public static Vector3 Position(this IReadOnlyCharacter character)
        {
            return character.Movement.Position;
        }
        
        public static bool ChestIsNear(this IReadOnlyCharacter character)
        {
            Physics.OverlapSphereNonAlloc(character.Movement.Position, 1.75f, _colliders);
            return _colliders.Any(collider => collider != null && collider.TryGetComponent(out _chest));
        }

        public static IChest Chest(this IReadOnlyCharacter character)
        {
            if (ChestIsNear(character) == false)
                throw new InvalidOperationException(nameof(ChestIsNear));

            return _chest;
        }

        public static bool CanOpenChest(this IReadOnlyCharacter character)
        {
            return ChestIsNear(character) && !_chest.IsOpen;
        }
    }
}