using ExitGames.Client.Photon;
using UnityEngine;

namespace HumansVsAliens.Tools
{
    public static class CustomTypesRegistration
    {
        private static readonly byte[] _buffer = new byte[1000];
        private static byte _code = 1;

        [RuntimeInitializeOnLoadMethod]
        public static void Register()
        {
            Register<GameConfigurationSave>();
        }

        private static void Register<T>() where T : ISaveObject, new()
        {
            _code += 1;
            PhotonPeer.RegisterType(typeof(T), _code, Serialize<T>, Deserialize<T>);
        }

        private static object Deserialize<T>(StreamBuffer inStream, short length) where T : ISaveObject, new()
        {
            T instance = new T();

            lock (_buffer)
            {
                inStream.Read(_buffer, 0, length);
                ISaveHandle readHandle = new SaveHandle(_buffer);
                instance.Deserialize(readHandle);
            }

            return instance;
        }

        private static short Serialize<T>(StreamBuffer outStream, object instance) where T : ISaveObject
        {
            T typedInstance = (T)instance;
            int length;

            lock (_buffer)
            {
                ISaveHandle saveHandle = new SaveHandle(_buffer);
                typedInstance.Serialize(saveHandle);
                length = saveHandle.CurrentIndex;
                outStream.Write(_buffer, 0, length);
            }

            return (short)length;
        }
    }
}