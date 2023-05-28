using System.Threading.Tasks;

namespace HumansVsAliens.SceneManagement
{
    public interface IAsyncScene
    {
        float LoadingProgress { get; }
        
        Task Load();
    }
}