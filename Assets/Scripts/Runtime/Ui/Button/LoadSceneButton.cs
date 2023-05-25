using System;
using HumansVsAliens.SceneManagement;

namespace HumansVsAliens.UI
{
    public sealed class LoadSceneButton : IButton
    {
        private readonly IScene _scene;

        public LoadSceneButton(IScene scene)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public void Press()
        {
            _scene.Load();
        }
    }
}