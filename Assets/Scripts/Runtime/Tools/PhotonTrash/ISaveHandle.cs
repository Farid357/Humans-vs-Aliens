namespace HumansVsAliens.Tools
{
    public interface ISaveHandle
    {
        int CurrentIndex { get; }

        int ReadInt();

        bool ReadBool();

        byte ReadByte();

        void WriteInt(int value);

        void WriteBool(bool value);

        void WriteByte(byte value);
    }
}