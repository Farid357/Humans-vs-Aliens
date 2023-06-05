using System;
using System.Linq;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class Leaderboard : MonoBehaviour, ILeaderboard
    {
        [SerializeField] private LeaderboardItem _itemPrefab;
        [SerializeField] private Transform _content;

        private IReadOnlyNetwork _network;

        public void Init(IReadOnlyNetwork network)
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
        }

        public void Show()
        {
            var sortedPlayers = _network.InRoomPlayers.ToList().OrderBy(player => player.GetScore());
            
            foreach (IReadOnlyNetworkPlayer player in sortedPlayers)
            {
                ILeaderboardItem item = Instantiate(_itemPrefab, _content);
                item.Visualize(player);
            }
        }
    }
}