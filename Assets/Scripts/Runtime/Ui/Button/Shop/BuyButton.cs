using System;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.UI
{
    public class BuyButton : IButton
    {
        private readonly IClient _client;

        public BuyButton(IClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public void Press()
        {
            if (!_client.HasEnoughMoney)
                return;

            _client.BuyGood();
        }
    }
}