using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class WavesCounterView : MonoBehaviour, IWavesCounterView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Visualize(int pastWaves)
        {
            _text.text = pastWaves.ToString();
        }
    }
}