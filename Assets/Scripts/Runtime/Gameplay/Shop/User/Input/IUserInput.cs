namespace HumansVsAliens.Gameplay
{
    public interface IUserInput
    {
        bool HasGood { get; }
        
        IGood Good { get; }
    }
}