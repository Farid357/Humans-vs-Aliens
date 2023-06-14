using BananaParty.BehaviorTree;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class AlienWarrior : Enemy
    {
        [SerializeField] private int _attackDamage = 10;
        [SerializeField] private EnemyAnimations _animations;

        protected override IBehaviorNode CreateBehaviourTree()
        {
            ICharacterSearcher forAttackCharacterSearcher = new CharacterSearcher(transform, DistanceToAttack);

            return new RepeatNode(new ParallelSequenceNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new MoveToClosestCharacterNode(Movement, new CharacterSearcher(transform, 50), 1.2f),
                }),

                new SequenceNode(new IBehaviorNode[]
                {
                    new WaitNode(1.2f),
                    new IsCharacterNearNode(forAttackCharacterSearcher),
                    new PlayAttackAnimationNode(_animations),
                    new AttackClosestCharacterNode(forAttackCharacterSearcher, _attackDamage),
                })
            }));
        }
    }
}