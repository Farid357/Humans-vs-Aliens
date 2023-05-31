using UnityEngine;

namespace HumansVsAliens.View
{
    public class VictoryView : MonoBehaviour, IVictoryView
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Window _victoryWindow;
        
        public void ShowVictory()
        {
            _victoryWindow.Open();
            _audioSource.Play();
        }
    }
}