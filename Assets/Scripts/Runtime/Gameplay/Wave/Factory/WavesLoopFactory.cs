using System.Collections.Generic;
using HumansVsAliens.Gameplay;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public sealed class WavesLoopFactory : MonoBehaviour
    {
        [SerializeField] private WavesFactory _wavesFactory;
        [SerializeField] private WavesCounterView _wavesCounterView;
        [SerializeField] private TimerBetweenWavesView _timerBetweenWavesView;
        [SerializeField] private WavesLoopSynchronization _loopSynchronization;

        private IWavesCounter _wavesCounter;

        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories)
        {
            _wavesCounter = new WavesCounter(_wavesCounterView);
            _wavesFactory.Init(enemiesWorld, enemyFactories);
        }

        public IWavesLoop Create(IGameConfigurationSave gameConfiguration)
        {
            ITimerBetweenWaves timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            IWavesLoop wavesLoop = new InfiniteWavesLoop(_wavesFactory.Create(), _wavesCounter, timerBetweenWaves);

            if (!gameConfiguration.WavesAreInfinite)
                wavesLoop = new WavesLoop(wavesLoop, _wavesCounter, gameConfiguration.WavesCount);
           
            _loopSynchronization.Init(wavesLoop);
            return wavesLoop;
        }
    }
}