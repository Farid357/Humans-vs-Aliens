using System.Collections.Generic;

namespace HumansVsAliens.Networking
{
    public interface IReadOnlyNetwork
    {
        bool IsMasterClient { get; }
        
        bool IsConnected { get; }
        
        IReadOnlyList<IRoom> Rooms { get; }

        IReadOnlyList<IReadOnlyNetworkPlayer> AllPlayers { get; }
        
        IReadOnlyList<IReadOnlyNetworkPlayer> InRoomPlayers { get; }
        
        INetworkPlayer Player { get; }
        
    }
}