namespace HumansVsAliens.Gameplay
{
    public interface IBonus
    {
        bool CanBePicked { get; }
        
        void PickUp();
    }
}