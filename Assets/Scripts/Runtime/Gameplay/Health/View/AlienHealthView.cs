using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class AlienHealthView : IHealthView
    {
        private readonly GameObject _gameObject;

        public AlienHealthView(GameObject gameObject)
        {
            _gameObject = gameObject ? gameObject : throw new System.ArgumentNullException(nameof(gameObject));
        }

        public void Visualize(int health)
        {
            
        }

        public void Die()
        {
            PhotonView photonView = PhotonView.Get(_gameObject);

            PhotonNetwork.Destroy(_gameObject);
        }
    }
}