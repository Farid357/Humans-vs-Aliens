using UnityEngine;

namespace HumansVsAliens.View
{
    public class BonusView : MonoBehaviour, IBonusView
    {
        [SerializeField] private AudioSource _pickAudio;

        public void PickUp()
        {
            //TODO Replace audio
            //  _pickAudio.Play();
            Destroy(gameObject);
        }
    }
}