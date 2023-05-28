using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class AlienHealthView : MonoBehaviour, IHealthView
    {
        public void Visualize(int health)
        {
        }

        public void Die()
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}