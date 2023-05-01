using System.Threading.Tasks;

namespace HumansVsAliens.SceneManagement
{
    public interface IAsyncScene
    {
        Task Load();

        void Unload();
        
        float LoadingProgress { get; }
    }
}