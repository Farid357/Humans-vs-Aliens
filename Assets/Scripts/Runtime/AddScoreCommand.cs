using System;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Model
{
    public class AddScoreCommand : IServerCommand<IScore>
    {
        private readonly IScore _score;

        public AddScoreCommand(IScore score)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public void Execute()
        {
            _score.Add(100);
        }
    }
}