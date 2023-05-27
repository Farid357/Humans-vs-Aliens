using System;
using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterSearcher : ICharacterSearcher
    {
        private readonly Transform _transform;
        private readonly float _radius;

        public CharacterSearcher(Transform transform, float radius)
        {
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            _radius = radius.ThrowIfLessOrEqualsToZeroException();
        }

        public IReadOnlyCharacter FoundCharacter { get; private set; }

        public bool HasFoundCharacter => FoundCharacter != null;
        
        public void Search()
        {
            IEnumerable<IReadOnlyCharacter> characters = FindCharacters();

            if (characters.Count() > 0)
            {
                FoundCharacter = characters.FindClosest(_transform);
                return;
            }

            FoundCharacter = null;
        }
        
        private IEnumerable<IReadOnlyCharacter> FindCharacters()
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, _radius);

            return colliders
                .Where(collider => collider.TryGetComponent(out IReadOnlyCharacter _))
                .Select(collider => collider.GetComponent<IReadOnlyCharacter>());
        }
    }
}