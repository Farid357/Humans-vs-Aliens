using System;
using System.Collections.Generic;
using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class MoveToClosestCharacterNode : BehaviorNode
    {
        private readonly IMovement _movement;
        private readonly ICharacterSearcher _characterSearcher;
        private readonly float _distanceToStopMovement;

        public MoveToClosestCharacterNode(IMovement movement, ICharacterSearcher characterSearcher, float distanceToStopMovement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _characterSearcher = characterSearcher ?? throw new ArgumentNullException(nameof(characterSearcher));
            _distanceToStopMovement = distanceToStopMovement.ThrowIfLessOrEqualsToZeroException();
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _characterSearcher.Search();

            if (_characterSearcher.HasFoundCharacter)
            {
                IReadOnlyCharacter character = _characterSearcher.FoundCharacter;
                Vector3 difference = character.Movement.Transform.position - _movement.Transform.position;

                if (difference.sqrMagnitude >= _distanceToStopMovement * _distanceToStopMovement)
                {
                    _movement.Move(difference.normalized);
                    return BehaviorNodeStatus.Success;
                }
            }

            return BehaviorNodeStatus.Failure;
        }
    }
}