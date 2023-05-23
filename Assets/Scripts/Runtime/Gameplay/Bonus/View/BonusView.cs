using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class BonusView : MonoBehaviour, IBonusView
    {
        [SerializeField] private AudioSource _pickAudio;
        
        public void PickUp()
        {
            //TODO Replace audio
            _pickAudio.Play();
            PhotonNetwork.Destroy(gameObject);
        }
    }
}