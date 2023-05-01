using System;
using System.Threading.Tasks;

namespace HumansVsAliens.SceneManagement
{
    public class SceneWithLoadingView : IScene
    {
        private readonly IAsyncScene _scene;
        private readonly ISceneLoadingView _loadingView;

        public SceneWithLoadingView(IAsyncScene scene, ISceneLoadingView loadingView)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _loadingView = loadingView ?? throw new ArgumentNullException(nameof(loadingView));
        }

        public async void Load()
        {
            Task loadTask = _scene.Load();

            while (!loadTask.IsCompleted)
            {
                _loadingView.Visualize(_scene.LoadingProgress);
                await Task.Yield();
            }
            
            _loadingView.Visualize(_scene.LoadingProgress);
        }

        public void Unload()
        {
            _scene.Unload();
        }
    }
}