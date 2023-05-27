namespace HumansVsAliens.Gameplay
{
    public interface ICharacterSearcher
    {
        bool HasFoundCharacter { get; }
        
        IReadOnlyCharacter FoundCharacter { get; }
        
        void Search();
    }
}