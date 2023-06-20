using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public sealed class User : IGameLoopObject
    {
        private readonly IClient _client;
        private readonly IReadOnlyShop _shop;
        private readonly IReadOnlyNetwork _network;
        private readonly UserInput _input;

        private int _goodIndex;

        public User(IClient client, IReadOnlyShop shop, IReadOnlyNetwork network)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
            _network = network ?? throw new ArgumentNullException(nameof(network));
            _input = new UserInput();
            _input.Enable();
        }

        public void Update(float deltaTime)
        {
            float scroll = _input.Shop.Scroll.ReadValue<float>();

            if (scroll >= 1)
                ScrollRight();

            if (scroll <= -1)
                ScrollLeft();

            if (_input.Shop.Buy.WasPerformedThisFrame() && _client.HasEnoughMoney)
                _client.BuySelectedGood();

            if (_input.Game.Exit.WasPerformedThisFrame() && _network.PlayerInRoom)
                _network.CurrentRoom.Leave();
        }

        private void ScrollLeft()
        {
            _goodIndex--;

            if (_goodIndex < 0)
                _goodIndex = _shop.Goods.Count - 1;

            _client.SelectGood(_shop.Goods[_goodIndex]);
        }

        private void ScrollRight()
        {
            _goodIndex++;

            if (_shop.Goods.Count == _goodIndex)
                _goodIndex = 0;

            _client.SelectGood(_shop.Goods[_goodIndex]);
        }
    }
}