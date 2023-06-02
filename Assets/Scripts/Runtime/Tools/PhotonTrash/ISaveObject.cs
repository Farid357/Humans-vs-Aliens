using HumansVsAliens.Tools;

namespace HumansVsAliens
{
    public interface ISaveObject
    {
        void Serialize(ISaveHandle saveHandle);

        void Deserialize(ISaveHandle saveHandle);
    }
}