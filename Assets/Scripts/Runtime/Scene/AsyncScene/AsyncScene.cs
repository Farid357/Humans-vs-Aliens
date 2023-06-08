using System;
using System.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.SceneManagement
{
    public sealed class AsyncScene : IAsyncScene
    {
        private readonly IScene _scene;
        
        public float LoadingProgress { get; private set; }

        public AsyncScene(IScene scene)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public async Task Load()
        {
            while (!Mathf.Approximately(LoadingProgress, 0.9f))
            {
                LoadingProgress += 0.1f;
                
                if(Mathf.Approximately(LoadingProgress, 0.5f))
                    _scene.Load();

                await Task.Yield();
            }

            LoadingProgress = 1f;
        }
    }
}