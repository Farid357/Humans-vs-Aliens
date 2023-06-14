using BananaParty.BehaviorTree;

namespace HumansVsAliens.Tools
{
    public static class BehaviourTreeExtensions
    {
        public static bool Finished(this IReadOnlyBehaviorNode behaviorNode)
        {
            return behaviorNode.Status == BehaviorNodeStatus.Success;
        }
    }
}