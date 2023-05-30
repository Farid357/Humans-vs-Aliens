namespace HumansVsAliens.Audio
{
    public interface IMusic
    {
        float Volume { get; }
        
        void ChangeVolume(float newVolume);
    }
}