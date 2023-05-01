using SaveSystem;
using UnityEditor;
using UnityEngine;

namespace HumansVsAliens.Editor
{
    public class SavesDeleteButton : MonoBehaviour
    {
        [MenuItem("Tools/Delete All Saves")]
        public static void Press()
        {
            ISavesStorage savesStorage = new SavesStorage();
            
            if(savesStorage.HasSaves())
                savesStorage.DeleteAllSaves();
        }
    }
}