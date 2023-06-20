using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Gameplay;
using HumansVsAliens.Tools;
using UnityEngine;
using Network = HumansVsAliens.Networking.Network;

namespace HumansVsAliens.Core
{
    public sealed class ShopFactory : MonoBehaviour
    {
        [SerializeField] private ClientView _clientView;
        [SerializeField] private GoodsFactory _goodsFactory;
        
        private readonly IGameLoopObjects _gameLoop = new GameLoopObjects();

        public IShopWithDiscounts Create(IWallet wallet, IReadOnlyCharacter character, IReadOnlyEnemiesWorld enemiesWorld, IReadOnlyWavesLoop wavesLoop)
        {
            _goodsFactory.Init(character, enemiesWorld);
            IDictionary<IGood,IGoodData> goods = _goodsFactory.Create();
            IShopWithDiscounts shop = new ShopWithDiscounts(new Shop());
            shop.Add(goods);

            IGameLoopObject temporaryDiscount = new BonusDiscount(wavesLoop, shop);
            IClient client = new Client(_clientView, shop, wallet);
            IGameLoopObject user = new User(client, shop, new Network());
            
            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>()
            {
                user,
                temporaryDiscount
            }));
            
            client.SelectGood(goods.Keys.First());
            return shop;
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}