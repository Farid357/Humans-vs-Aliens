using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class GoodWithViewFactory : MonoBehaviour
    {
        [SerializeField] private GoodWithView _prefab;
        [SerializeField] private Transform _content;

        public IGood CreateFor(IGood good)
        {
            GoodWithView goodWithView = Instantiate(_prefab, _content);
            goodWithView.Init(good);
            return goodWithView;
        }
    }
}