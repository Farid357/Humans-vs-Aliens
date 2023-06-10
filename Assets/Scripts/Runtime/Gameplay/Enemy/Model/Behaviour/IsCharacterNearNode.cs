using System;
using BananaParty.BehaviorTree;

namespace HumansVsAliens.Gameplay
{
    public class IsCharacterNearNode : BehaviorNode
    {
        private readonly ICharacterSearcher _characterSearcher;
        
        public IsCharacterNearNode(ICharacterSearcher characterSearcher)
        {
            _characterSearcher = characterSearcher ?? throw new ArgumentNullException(nameof(characterSearcher));
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _characterSearcher.Search();
            return _characterSearcher.HasFoundCharacter ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}