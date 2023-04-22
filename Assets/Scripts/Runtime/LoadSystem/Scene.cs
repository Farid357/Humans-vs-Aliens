using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HumansVsAliens.LoadSystem
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Create/Scene Data")]
    public class Scene : ScriptableObject, IScene, ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _scene;
#endif
        [field: SerializeField] public string Name { get; private set; }
       
        public void Load()
        {
            SceneManager.LoadScene(Name);
        }

        public void Unload()
        {
            SceneManager.UnloadSceneAsync(Name);
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