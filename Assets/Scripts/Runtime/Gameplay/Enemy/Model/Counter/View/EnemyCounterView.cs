using DG.Tweening;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class EnemyCounterView : MonoBehaviour, IEnemyCounterView
    {
        [SerializeField] private TMP_Text _text;
        
        private PhotonView _photonView;
        private int _showingCount;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }
        
        public void Show(int enemiesCount)
        {
            _photonView.RPC(nameof(ShowRpc), RpcTarget.All, enemiesCount);
        }
        
        [PunRPC]
        private void ShowRpc(int enemiesCount)
        {
            if (_showingCount > enemiesCount)
            {
                Color color = _text.color;
                _text.DOColor(Color.red, 0.4f).OnComplete(() => _text.color = color);
            }

            _showingCount = enemiesCount;
            _text.text = enemiesCount.ToString();
        }
    }
}