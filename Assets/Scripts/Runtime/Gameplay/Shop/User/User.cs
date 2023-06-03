using System;
using HumansVsAliens.GameLoop;

namespace HumansVsAliens.Gameplay
{
    public sealed class User : IGameLoopObject
    {
        private readonly IUserInput _input;
        private readonly IClient _client;

        private IGood _lastSelectedGood;

        public User(IUserInput input, IClient client)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public void Update(float deltaTime)
        {
            if (_input.HasGood && _lastSelectedGood != _input.Good)
            {
                _lastSelectedGood = _input.Good;
                _client.SelectGood(_lastSelectedGood);
            }
        }
    }
}