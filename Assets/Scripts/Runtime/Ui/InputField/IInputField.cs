namespace HumansVsAliens.UI
{
    public interface IInputField
    {
        string Text { get; }
        
        bool IsValid { get; }
    }
}