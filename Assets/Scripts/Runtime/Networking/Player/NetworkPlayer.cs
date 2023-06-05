using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace HumansVsAliens.Networking
{
    public class NetworkPlayer : INetworkPlayer
    {
        private readonly Player _player;

        public NetworkPlayer(string name)
        {
            _player = PhotonNetwork.LocalPlayer;
            string number = _player.ActorNumber > 0 ? _player.ActorNumber.ToString() : "";
            Name = string.IsNullOrWhiteSpace(name) ? $"Guest{number}" : name;
        }

        public string Name { get; }

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
    }
}