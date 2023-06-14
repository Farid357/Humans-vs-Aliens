namespace HumansVsAliens.Gameplay
{
    public interface ICharacterMovement : IMovement
    {
        bool OnGround { get; }

        void Jump();
    }
}