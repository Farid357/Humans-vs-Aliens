namespace HumansVsAliens
{
    public interface IRoomData
    {
        int CurrentPlayersCount { get; }
        
        int MaxPlayersCount { get; }
        
        string Name { get; }
    }
}