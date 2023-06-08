namespace HumansVsAliens.Networking
{
    public interface IReadOnlyRoom
    {
        bool IsPlayerIn { get; }
        
        int CurrentPlayersCount { get; }
        
        int MaxPlayersCount { get; }
        
        string Name { get; }
    }
}