using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens
{
    public class MainMenuBackground : MonoBehaviour
    {
        [SerializeField] private Sprite[] _icons;
        [SerializeField] private Image _background;
        [SerializeField] private float _delayBetweenIcons = 30f;
        [SerializeField] private float _fadeDuration = 1.5f;

        private void Start() => ChangeIcon().Forget();

        private async UniTaskVoid ChangeIcon()
        {
            _background.sprite = _icons.First();
            Color startColor = _background.color;
            int iconIndex = 0;
            var cancellationToken = this.GetCancellationTokenOnDestroy();

            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_delayBetweenIcons), cancellationToken: cancellationToken);

                if (cancellationToken.IsCancellationRequested == false)
                    return;

                _background.DOColor(Color.black, _fadeDuration);
                await UniTask.Delay(TimeSpan.FromSeconds(_fadeDuration), cancellationToken: cancellationToken);

                if (cancellationToken.IsCancellationRequested == false)
                    return;

                iconIndex++;
                if (iconIndex == _icons.Length)
                    iconIndex = 0;

                _background.sprite = _icons[iconIndex];
                _background.DOColor(startColor, _fadeDuration / 2f);
            }
        }
    }
}