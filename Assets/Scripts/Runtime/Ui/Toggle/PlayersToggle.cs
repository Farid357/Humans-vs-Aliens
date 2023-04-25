using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens
{
    public sealed class PlayersToggle : MonoBehaviour, IPlayersToggle
    {
        [SerializeField] private PlayerToggle[] _toggles;

        public byte SelectedPlayersCount => _toggles.First(toggle => toggle.Toggle.isOn).PlayersCount;
        
        [Serializable]
        public struct PlayerToggle
        {
            [field: SerializeField] public Toggle Toggle { get; private set; }
            
            [field: SerializeField, Min(2)] public byte PlayersCount { get; private set; }
        }
    }
}