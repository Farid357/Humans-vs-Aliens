using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class AlienHealthView : IHealthView
    {
        private readonly GameObject _gameObject;

        public AlienHealthView(GameObject gameObject)
        {
            _gameObject = gameObject ?? throw new System.ArgumentNullException(nameof(gameObject));
        }

        public void Visualize(int health)
        {
            
        }

        public void Die()
        {
            PhotonNetwork.Destroy(_gameObject);
        }
    }
}