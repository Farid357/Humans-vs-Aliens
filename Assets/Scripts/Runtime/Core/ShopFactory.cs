using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Gameplay;
using HumansVsAliens.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.Core
{
    public class ShopFactory : MonoBehaviour
    {
        [SerializeField] private UnityButton _buyButton;
        [SerializeField] private ClientView _clientView;
        [SerializeField] private GoodsFactory _goodsFactory;
        [SerializeField] private GraphicRaycaster _physicsRaycaster;
        
        private readonly IGameLoopObjects _gameLoop = new GameLoopObjects();

        public IShop Create(IWallet wallet, IReadOnlyCharacter character, IReadOnlyEnemiesWorld enemiesWorld)
        {
            _goodsFactory.Init(character, enemiesWorld);
            Dictionary<IGood,IGoodData> goods = _goodsFactory.Create();
            IShop shop = new Shop(goods);
            IClient client = new Client(_clientView, shop, wallet);
            var userInput = new UserInput(_physicsRaycaster);
            IGameLoopObject user = new User(userInput, client);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>()
            {
                userInput,
                user
            }));

            _buyButton.Init(new BuyButton(client));
            client.SelectGood(goods.Keys.First());
            return shop;
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}