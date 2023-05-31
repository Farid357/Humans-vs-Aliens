using SaveSystem;
using SaveSystem.Paths;

namespace HumansVsAliens.Gameplay
{
    public static class SaveStorages
    {
        public static ISaveStorage<GameConfigurationSave> GameConfiguration =
            new BinaryStorage<GameConfigurationSave>(new Path(nameof(GameConfigurationSave)));
    }
}