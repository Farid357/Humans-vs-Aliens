using ExitGames.Client.Photon;
using HumansVsAliens.Gameplay;
using HumansVsAliens.Networking;
using Photon.Pun;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace HumansVsAliens.Core
{
    public class CustomTypesRegistration : MonoBehaviour
    {
        private byte _code = 1;

        private void Awake()
        {
            Register<PrepareGameCommand>();
        }

        private void Register<TCommand>() where TCommand : IServerCommand
        {
            PhotonPeer.RegisterType(typeof(TCommand), _code, Serialize, Deserialize);
            _code += 1;
        }

        private object Deserialize(byte[] serializedCustomObject)
        {
            return 0;

        }

        private byte[] Serialize(object customObject)
        {
            var binaryFormatter = new BinaryFormatter();
            using var memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, customObject);
            return memoryStream.ToArray();
        }
        
    }
}