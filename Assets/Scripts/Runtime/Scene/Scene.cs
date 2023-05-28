using Photon.Pun;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HumansVsAliens.SceneManagement
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Create/Scene Data")]
    public class Scene : ScriptableObject, IScene, ISceneData, ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _scene;
#endif
        [field: SerializeField, ReadOnly] public string Name { get; private set; }

        public void Load()
        {
            SceneManager.LoadScene(Name);
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