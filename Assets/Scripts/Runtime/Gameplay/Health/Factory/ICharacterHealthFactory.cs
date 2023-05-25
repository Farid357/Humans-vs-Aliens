using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public interface ICharacterHealthFactory
    {
        IHealth Create(IHealthAnimations animations);
    }
}