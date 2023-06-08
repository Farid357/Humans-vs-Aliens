using System.Globalization;
using HumansVsAliens.Tools;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.SceneManagement
{
    public sealed class SceneLoadingView : MonoBehaviour, ISceneLoadingView
    {
        [SerializeField] private TMP_Text _progressText;
        [SerializeField] private Window _loadingWindow;
        
        public void Visualize(float loadingProgress)
        {
            if (!_loadingWindow.IsActive)
                _loadingWindow.Open();

            string text = loadingProgress.ToString();
            loadingProgress = text.Length >= 3 ? text[..3].ToFloat() : loadingProgress;
            loadingProgress *= 100f;
            string progressText = loadingProgress.ToString(CultureInfo.InvariantCulture);
            _progressText.text = $"{progressText}%";
        }
    }
}