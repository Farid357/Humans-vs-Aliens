using HumansVsAliens.Networking;

namespace HumansVsAliens.Model
{
    public class AddScoreCommand : IServerCommand<IScore>
    {
        public void Execute(IScore score)
        {
            score.Add(100);
        }
    }
}