using System;
using BananaParty.BehaviorTree;

namespace HumansVsAliens.Gameplay
{
    public class WeaponAttackNode : BehaviorNode
    {
        private readonly IWeapon _weapon;

        public WeaponAttackNode(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_weapon.CanShoot)
            {
                _weapon.Shoot();
                return BehaviorNodeStatus.Success;
            }

            return BehaviorNodeStatus.Failure;
        }
    }
}