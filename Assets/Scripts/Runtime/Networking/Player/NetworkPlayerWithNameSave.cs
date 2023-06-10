using System;
using SaveSystem;
using SaveSystem.Paths;

namespace HumansVsAliens.Networking
{
    public class NetworkPlayerWithNameSave : INetworkPlayer
    {
        private readonly INetworkPlayer _player;
        private readonly ISaveStorage<string> _nameStorage;

        public NetworkPlayerWithNameSave(INetworkPlayer player, ISaveStorage<string> nameStorage)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _nameStorage = nameStorage ?? throw new ArgumentNullException(nameof(nameStorage));
            
            if(_nameStorage.HasSave())
                _player.SwitchName(_nameStorage.Load());
        }

        public NetworkPlayerWithNameSave() : this(new NetworkPlayer(), new BinaryStorage<string>(new Path(nameof(INetworkPlayer))))
        {
        }

        public string Name => _player.Name;

        public object GetCustomData(string key) => _player.GetCustomData(key);

        public void SetCustomData(string key, object data)
        {
            _player.SetCustomData(key, data);
        }

        public void SwitchName(string newName)
        {
            _player.SwitchName(newName);
            _nameStorage.Save(newName);
        }
    }
}