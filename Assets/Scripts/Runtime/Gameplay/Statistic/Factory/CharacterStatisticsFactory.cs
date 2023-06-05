using HumansVsAliens.Networking;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{ 
    public class CharacterStatisticsFactory : MonoBehaviour
    {
        [SerializeField] private WalletFactory _walletFactory;
        [SerializeField] private ScoreFactory _scoreFactory;

        public ICharacterStatistics Create(IReadOnlyNetwork network)
        {
            IScore score = _scoreFactory.Create(network);
            IWallet wallet = _walletFactory.Create();
            return new CharacterStatistics(wallet, score);
        }
    }
}