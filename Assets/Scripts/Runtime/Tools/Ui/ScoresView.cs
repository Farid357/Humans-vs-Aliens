using ExitGames.Client.Photon;
using HumansVsAliens.Tools;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ScoresView : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_Text _text;

        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
            _text.text = "";

            foreach (var player in PhotonNetwork.PlayerList)
            {
                _text.text += $"{player.NickName} - {player.GetScore()}\n";
            }
        }
    }
}