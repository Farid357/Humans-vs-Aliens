using Cysharp.Threading.Tasks;
using Photon.Pun;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace HumansVsAliens.SceneManagement
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Create/Scene Data")]
    public class Scene : ScriptableObject, IScene, ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _scene;
#endif
        [field: SerializeField, ReadOnly] public string Name { get; private set; }

        public async void Load()
        {
            while (!PhotonNetwork.InRoom)
                await UniTask.Yield();

            PhotonNetwork.LoadLevel(Name);
        }

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR

            if (_scene != null)
                Name = _scene.name;
#endif
        }
    }
}