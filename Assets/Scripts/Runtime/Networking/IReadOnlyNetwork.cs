using System.Collections.Generic;

namespace HumansVsAliens.Networking
{
    public interface IReadOnlyNetwork
    {
        bool IsMasterClient { get; }
        
        IReadOnlyList<IReadOnlyNetworkPlayer> AllPlayers { get; }
        
        IReadOnlyList<IReadOnlyNetworkPlayer> InRoomPlayers { get; }
        
        INetworkPlayer Player { get; }
        
        bool IsConnected { get; }
    }
}