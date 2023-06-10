using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.Gameplay;
using UnityEngine;

namespace HumansVsAliens.Tools
{
    public static class TransformExtensions
    {
        public static IReadOnlyCharacter FindClosest(this IEnumerable<IReadOnlyCharacter> characters, Transform to)
        {
            IReadOnlyCharacter[] readOnlyCharacters = characters as IReadOnlyCharacter[] ?? characters.ToArray();
            Vector3[] convertedTPositions = readOnlyCharacters.Select(character => character.Movement.Position).ToArray();
            Vector3 closest = convertedTPositions[0];

            for (int i = 1; i < convertedTPositions.Length; i++)
            {
                float anotherDistance = (convertedTPositions[i] - to.position).sqrMagnitude;
                float distanceToClosest = (closest - to.position).sqrMagnitude;

                if (distanceToClosest > anotherDistance)
                {
                    closest = convertedTPositions[i];
                }
            }

            return readOnlyCharacters.First(character => character.Position() == closest);
        }
    }
}