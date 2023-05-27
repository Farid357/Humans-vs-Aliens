using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.Gameplay;
using UnityEngine;

namespace HumansVsAliens.Tools
{
    public static class TransformExtensions
    {
        public static Transform FindClosestTo(this IEnumerable<Transform> transforms, Transform to)
        {
            var convertedTransforms = transforms as Transform[] ?? transforms.ToArray();
            Transform closest = convertedTransforms[0];

            for (int i = 1; i < convertedTransforms.Length; i++)
            {
                float anotherDistance = (convertedTransforms[i].position - to.position).sqrMagnitude;
                float distanceToClosest = (closest.position - to.position).sqrMagnitude;
              
                if (distanceToClosest > anotherDistance)
                {
                    closest = convertedTransforms[i];
                }
            }

            return closest;
        }

        public static IReadOnlyCharacter FindClosest(this IEnumerable<IReadOnlyCharacter> characters, Transform to)
        {
            return FindClosestTo(characters.Select(character => character.Movement.Transform), to)
                .GetComponent<IReadOnlyCharacter>();
        }
    }
}