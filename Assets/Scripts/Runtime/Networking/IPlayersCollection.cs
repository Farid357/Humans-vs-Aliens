using System.Collections.Generic;

namespace HumansVsAliens.Networking
{
    public interface IPlayersCollection
    {
        INetworkPlayer LocalPlayer { get; }

        IReadOnlyList<IReadOnlyNetworkPlayer> AllPlayers { get; }

        IReadOnlyList<IReadOnlyNetworkPlayer> InRoomPlayers { get; }
    }
}