namespace HumansVsAliens.Tools
{
    public class SaveHandle : ISaveHandle
    {
        private readonly byte[] _data;

        public SaveHandle(byte[] data)
        {
            _data = data;
            CurrentIndex = 0;
        }

        public int CurrentIndex { get; private set; }

        public void WriteInt(int value)
        {
            for (int i = 0; i < sizeof(int); ++i)
            {
                _data[CurrentIndex] = (byte)(value >> (i * 8));
                CurrentIndex += 1;
            }
        }

        public void WriteBool(bool value)
        {
            _data[CurrentIndex] = (byte)(value == true ? 1 : 0);
            CurrentIndex += 1;
        }

        public void WriteByte(byte value)
        {
            _data[CurrentIndex] = value;
            CurrentIndex += 1;
        }

        public int ReadInt()
        {
            int result = 0;

            for (int i = 0; i < sizeof(int); ++i)
            {
                result |= _data[CurrentIndex] << (i * 8);
                CurrentIndex += 1;
            }

            return result;
        }

        public bool ReadBool()
        {
            bool result = _data[CurrentIndex] == 1;
            CurrentIndex += 1;
            return result;
        }

        public byte ReadByte()
        {
            byte result = _data[CurrentIndex];
            CurrentIndex += 1;
            return result;
        }
    }
}