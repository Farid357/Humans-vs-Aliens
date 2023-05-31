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

        private IWavesCounter _wavesCounter;
        
        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType,IEnemyFactory> enemyFactories)
        {
            _wavesCounter = new WavesCounter(_wavesCounterView);
            _wavesFactory.Init(enemiesWorld, enemyFactories);
        }
        
        public IWavesLoop Create()
        {
            ITimerBetweenWaves timerBetweenWaves = new TimerBetweenWaves(_timerBetweenWavesView);
            return new WavesLoop(_wavesFactory.Create(), _wavesCounter, timerBetweenWaves);
        }
        
        public IWavesLoop CreateTemporary(int wavesCount)
        {
            IWavesLoop wavesLoop = Create();
            return new TemporaryWavesLoop(wavesLoop, _wavesCounter, wavesCount);
        }
    }
}