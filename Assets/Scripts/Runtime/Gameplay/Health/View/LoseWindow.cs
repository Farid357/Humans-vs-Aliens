using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.View
{
    public sealed class LoseWindow : MonoBehaviour
    {
        [SerializeField] private float _secondsToClearColor = 4.5f;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        
        public void Open()
        {
            gameObject.SetActive(true);
            _image.DOColor(Color.clear, _secondsToClearColor);
            _text.DOColor(Color.clear, _secondsToClearColor);
        }
    }
}