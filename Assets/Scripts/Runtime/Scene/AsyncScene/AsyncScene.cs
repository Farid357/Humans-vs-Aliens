using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HumansVsAliens.SceneManagement
{
    public sealed class AsyncScene : IAsyncScene
    {
        private readonly string _name;
        
        public float LoadingProgress { get; private set; }

        public AsyncScene(ISceneData sceneData)
        {
            _name = sceneData.Name;
        }

        public async Task Load()
        {
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(_name);
            loadSceneOperation.allowSceneActivation = false;

            while (!Mathf.Approximately(LoadingProgress, 0.9f))
            {
                LoadingProgress = loadSceneOperation.progress;
                await Task.Yield();
            }

            LoadingProgress = 1f;
            loadSceneOperation.allowSceneActivation = true;
        }
    }
}