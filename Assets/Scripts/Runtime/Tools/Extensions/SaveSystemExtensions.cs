using SaveSystem;

namespace HumansVsAliens.Tools
{
    public static class SaveSystemExtensions
    {
        public static T LoadOrDefault<T>(this ISaveStorage<T> saveStorage) where T : new()
        {
            return saveStorage.HasSave() ? saveStorage.Load() : new T();
        }
    }
}