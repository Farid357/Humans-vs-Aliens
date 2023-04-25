namespace HumansVsAliens
{
    public interface IInputField
    {
        string Text { get; }
        
        bool IsValid { get; }
    }
}