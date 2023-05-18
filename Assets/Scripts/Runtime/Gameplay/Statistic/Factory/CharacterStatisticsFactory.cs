using UnityEngine;

namespace HumansVsAliens.Gameplay
{ 
    public class CharacterStatisticsFactory : MonoBehaviour
    {
        [SerializeField] private WalletFactory _walletFactory;
        [SerializeField] private ScoreFactory _scoreFactory;

        public ICharacterStatistics Create()
        {
            IScore score = _scoreFactory.Create();
            IWallet wallet = _walletFactory.Create();
            return new CharacterStatistics(wallet, score);
        }
    }
}