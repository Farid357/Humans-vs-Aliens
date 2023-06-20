using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class GoodWithViewFactory : MonoBehaviour
    {
        [SerializeField] private GoodView _prefab;
        [SerializeField] private Transform _content;

        public IGood CreateFor(IGood good)
        {
            IGoodView view = Instantiate(_prefab, _content);
            IGood goodWithView = new GoodWithView(good, view);
            return goodWithView;
        }
    }
}