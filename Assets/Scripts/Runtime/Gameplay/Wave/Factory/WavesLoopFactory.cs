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
        
        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType,IEnemyFactory> enemyFactories)
        {
            _wavesCounter = new WavesCounter(_wavesCounterView);
            _wavesFactory.Init(enemiesWorld, enemyFactories);
        }
        
        public IWavesLoop CreateInfinite()
        {
            ITimerBetweenWaves timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            IWavesLoop wavesLoop = new InfiniteWavesLoop(_wavesFactory.Create(), _wavesCounter, timerBetweenWaves);
            _loopSynchronization.Init(wavesLoop);
            return wavesLoop;
        }
        
        public IWavesLoop Create(int wavesCount)
        {
            IWavesLoop infiniteWavesLoop = CreateInfinite();
            IWavesLoop wavesLoop = new WavesLoop(infiniteWavesLoop, _wavesCounter, wavesCount);
            _loopSynchronization.Init(wavesLoop);
            return wavesLoop;
        }
    }
}