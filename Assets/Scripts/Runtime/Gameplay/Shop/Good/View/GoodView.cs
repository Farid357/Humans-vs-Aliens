using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.View
{
    public class GoodView : MonoBehaviour, IGoodView
    {
        [SerializeField] private Image _image;
        [SerializeField] private Color _boughtColor = Color.gray;
        [SerializeField] private Image _boughtImage;
        
        public void Buy()
        {
            _image.color = _boughtColor;
            _boughtImage.gameObject.SetActive(true);
        }
    }
}