namespace HumansVsAliens.Gameplay
{
    public interface ICharacterCamera
    {
        bool IsInFullZoomIn { get; }
        
        bool IsInFullZoomOut { get; }

        void ZoomIn();
        
        void ZoomOut();
    }
}