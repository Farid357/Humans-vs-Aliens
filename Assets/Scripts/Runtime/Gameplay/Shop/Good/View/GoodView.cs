using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.View
{
    public class GoodView : MonoBehaviour, IGoodView
    {
        [SerializeField] private Image _image;
        [SerializeField] private Color _boughtColor = Color.gray;

        public async void Use()
        {
            Color startColor = _image.color;
            _image.color = _boughtColor;
            await UniTask.Delay(1500);
            _image.color = startColor;
        }
    }
}