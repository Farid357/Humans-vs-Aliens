using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private int _health = 80;

        public IEnemy Create(Vector3 position)
        {
            Enemy enemy = PhotonNetwork.Instantiate(_enemyPrefab.name, position, Quaternion.identity).GetComponent<Enemy>();
            PhotonView photonView = PhotonView.Get(enemy);
            photonView.RPC(nameof(enemy.Init), RpcTarget.AllBuffered, _health);
            return enemy;
        }
    }
}