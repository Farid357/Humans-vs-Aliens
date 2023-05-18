using HumansVsAliens.View;
using SaveSystem;
using SaveSystem.Paths;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class WalletFactory : MonoBehaviour, IWalletFactory
    {
        [SerializeField] private WalletView _view;

        public IWallet Create()
        {
            ISaveStorage<int> moneyStorage = new BinaryStorage<int>(new Path(nameof(IWallet)));
            int money = moneyStorage.HasSave() ? moneyStorage.Load() : 100;
            _view.Visualize(money);
            return new WalletWithSave(new Wallet(money, _view), moneyStorage);
        }
    }
}