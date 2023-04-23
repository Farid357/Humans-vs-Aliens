using System.Threading.Tasks;

namespace HumansVsAliens.LoadSystem
{
    public interface IAsyncScene
    {
        Task Load();

        void Unload();
        
        float LoadingProgress { get; }
    }
}