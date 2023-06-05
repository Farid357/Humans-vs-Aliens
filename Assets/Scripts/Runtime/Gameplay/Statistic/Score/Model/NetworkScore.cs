using System;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class NetworkScore : IScore
    {
        private readonly IScore _score;
        private readonly IReadOnlyNetwork _network;

        public NetworkScore(IScore score, IReadOnlyNetwork network)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _network = network ?? throw new ArgumentNullException(nameof(network));
            _network.Player.SetScore(0);
        }

        public int Count => _score.Count;

        public void Add(int count)
        {
            _score.Add(count);
            _network.Player.SetScore(_score.Count);
        }
    }
}