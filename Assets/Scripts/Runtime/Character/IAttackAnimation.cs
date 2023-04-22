namespace HumansVsAliens.View
{
    public interface IAttackAnimation
    {
        bool IsPlayingAttack { get; }
        
        void PlayAttack();
    }
}