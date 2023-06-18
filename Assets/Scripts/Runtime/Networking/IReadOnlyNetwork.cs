namespace HumansVsAliens.Networking
{
    public interface IReadOnlyNetwork : IPlayersCollection, IRoomsCollection
    {
        bool IsMasterClient { get; }

        bool IsConnected { get; }

    }
}