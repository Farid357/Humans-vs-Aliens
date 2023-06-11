using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class AlienFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Alien _alienPrefab;
        [SerializeField] private int _health = 80;

        public IEnemy Create(Vector3 position)
        {
            Alien alien = PhotonNetwork.Instantiate(_alienPrefab.name, position, Quaternion.identity).GetComponent<Alien>();
            PhotonView photonView = PhotonView.Get(alien);
            photonView.RPC(nameof(alien.Init), RpcTarget.AllBuffered, _health);
            return alien;
        }
    }
}