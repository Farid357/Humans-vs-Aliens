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
            AsyncOperation loadScene = SceneManager.LoadSceneAsync(_name);
            loadScene.allowSceneActivation = false;

            while (!Mathf.Approximately(LoadingProgress, 0.9f))
            {
                LoadingProgress = loadScene.progress;
                await Task.Yield();
            }

            LoadingProgress = 1f;
            loadScene.allowSceneActivation = true;
        }

        public void Unload()
        {
            SceneManager.UnloadSceneAsync(_name);
        }
    }
}