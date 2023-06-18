namespace HumansVsAliens.Networking
{
    public interface IReadOnlyNetwork : IPlayersCollection, IRoomsCollection
    {
        bool IsMasterClient { get; }

        bool IsConnected { get; }

        bool PlayerInRoom { get; }
    }
}