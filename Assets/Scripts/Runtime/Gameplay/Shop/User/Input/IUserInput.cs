namespace HumansVsAliens.Gameplay
{
    public interface IUserInput
    {
        bool ClickedOnGood();
        
        IGood Good { get; }
    }
}