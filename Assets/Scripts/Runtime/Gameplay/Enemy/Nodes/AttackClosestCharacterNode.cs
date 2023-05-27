using System;
using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class AttackClosestCharacterNode : BehaviorNode
    {
        private readonly ICharacterSearcher _characterSearcher;
        private readonly int _damage;

        public AttackClosestCharacterNode(ICharacterSearcher characterSearcher, int damage)
        {
            _characterSearcher = characterSearcher ?? throw new ArgumentNullException(nameof(characterSearcher));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _characterSearcher.Search();

            if (_characterSearcher.HasFoundCharacter)
            {
                IReadOnlyCharacter character = _characterSearcher.FoundCharacter;

                if (character.IsAlive)
                {
                    character.Health.TakeDamage(_damage);
                    return BehaviorNodeStatus.Success;
                }
            }

            return BehaviorNodeStatus.Failure;
        }
    }
}