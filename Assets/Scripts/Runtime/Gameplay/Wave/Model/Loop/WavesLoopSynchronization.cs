using System;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class WavesLoopSynchronization : MonoBehaviour, IPunObservable
    {
        private IWavesLoop _wavesLoop;

        public void Init(IWavesLoop wavesLoop)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
        }
        
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext((int)_wavesLoop.Status);
            }
            
            else
            {
                int status = (int)stream.ReceiveNext();
                _wavesLoop.SetStatus((WavesLoopStatus)status);
            }
        }
    }
}