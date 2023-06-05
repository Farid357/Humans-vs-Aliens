using HumansVsAliens.Networking;
using HumansVsAliens.Tools;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class LeaderboardItem : MonoBehaviour, ILeaderboardItem
    {
        [SerializeField] private TMP_Text _nick;
        [SerializeField] private TMP_Text _score;

        public void Visualize(IReadOnlyNetworkPlayer player)
        {
            _nick.text = player.Name;
            _score.text = player.GetScore().ToString();
        }
    }
}