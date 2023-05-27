using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace HumansVsAliens.Networking
{
    public class Network : INetwork, IConnectionCallbacks, IDisposable
    {
        public Network()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public bool IsConnected => PhotonNetwork.IsConnected;
        
        public bool IsMasterClient => PhotonNetwork.IsMasterClient;
        
        public void Connect()
        {
            if (IsConnected)
                throw new InvalidOperationException($"Network is already connected!");
            
            PhotonNetwork.ConnectUsingSettings();
        }

        public void OnConnected()
        {
            Debug.Log("Connected!");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log("Connected to master!");
            PhotonNetwork.JoinLobby();
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
        
        public void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected {cause}!");
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }
    }
}