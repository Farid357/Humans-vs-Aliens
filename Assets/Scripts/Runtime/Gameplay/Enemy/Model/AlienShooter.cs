using BananaParty.BehaviorTree;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class AlienShooter : Enemy
    {
        [SerializeField] private WeaponFactory _weaponFactory;

        protected override IBehaviorNode CreateBehaviourTree()
        {
            IWeapon weapon = _weaponFactory.Create(new EnemyWeaponAim(transform, DistanceToAttack));
         
            return new RepeatNode(new ParallelSequenceNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsCharacterNearNode(new CharacterSearcher(transform, 3.5f)),
                    new RetreatNode(Movement),
                }),

                new SequenceNode(new IBehaviorNode[]
                {
                    new WaitNode(1.2f),
                    new IsCharacterNearNode(new CharacterSearcher(transform, DistanceToAttack)),
                    new WeaponAttackNode(weapon),
                })
            }));
        }
    }
}