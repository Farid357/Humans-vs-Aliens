using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Gameplay;
using HumansVsAliens.UI;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public class ShopFactory : MonoBehaviour
    {
        [SerializeField] private UnityButton _buyButton;
        [SerializeField] private ClientView _clientView;
        [SerializeField] private GoodsFactory _goodsFactory;

        private readonly IGameLoopObjects _gameLoop = new GameLoopObjects();

        public IShop Create(IWallet wallet, IReadOnlyCharacter character, IReadOnlyEnemiesWorld enemiesWorld)
        {
            _goodsFactory.Init(character, enemiesWorld);
            IShop shop = new Shop(_goodsFactory.Create());
            IClient client = new Client(_clientView, shop, wallet);
            var userInput = new UserInput();
            IGameLoopObject user = new User(userInput, client);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>()
            {
                userInput,
                user
            }));

            _buyButton.Init(new BuyButton(client));
            return shop;
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}