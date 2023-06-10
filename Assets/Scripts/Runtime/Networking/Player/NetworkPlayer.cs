using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class NetworkPlayer : INetworkPlayer
    {
        private readonly Player _player;

        public NetworkPlayer(Player player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public NetworkPlayer() : this(PhotonNetwork.LocalPlayer)
        {
        }

        public string Name => _player.NickName;

        public object GetCustomData(string key)
        {
            if (_player.CustomProperties.ContainsKey(key))
                return _player.CustomProperties[key];

            throw new InvalidOperationException($"Player doesn't contain data with key: {key}");
        }

        public void SetCustomData(string key, object data)
        {
            var hashtable = new Hashtable { { key, data } };
            _player.SetCustomProperties(hashtable);
        }

        public void SwitchName(string newName)
        {
            _player.NickName = newName;
        }
    }
}