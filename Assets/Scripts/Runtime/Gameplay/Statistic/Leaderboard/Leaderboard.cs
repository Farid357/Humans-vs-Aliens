using System;
using System.Linq;
using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public class Leaderboard : MonoBehaviour, ILeaderboard
    {
        [SerializeField] private LeaderboardItem _itemPrefab;
        [SerializeField] private Transform _content;

        private IReadOnlyNetwork _network;
        private PhotonView _photonView;
        
        public void Init(IReadOnlyNetwork network)
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
            _photonView = GetComponent<PhotonView>();
        }

        public void Show()
        {
            _photonView.RPC(nameof(ShowRpc), RpcTarget.All);
        }
        
        [PunRPC]
        private void ShowRpc()
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