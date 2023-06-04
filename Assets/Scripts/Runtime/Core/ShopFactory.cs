using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Gameplay;
using HumansVsAliens.Tools;
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

        public IShop Create(IWallet wallet, IReadOnlyCharacter character, IReadOnlyEnemiesWorld enemiesWorld, IReadOnlyWavesLoop wavesLoop)
        {
            _goodsFactory.Init(character, enemiesWorld);
            IDictionary<IGood,IGoodData> goods = _goodsFactory.Create();
            IShopWithDiscounts shop = new ShopWithDiscounts(new Shop());
            shop.Add(goods);

            IGameLoopObject temporaryDiscount = new BonusDiscount(wavesLoop, shop);
            IClient client = new Client(_clientView, shop, wallet);
            IUserInput userInput = new UserInput(_physicsRaycaster);
            IGameLoopObject user = new User(userInput, client);
            
            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>()
            {
                user,
                temporaryDiscount
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