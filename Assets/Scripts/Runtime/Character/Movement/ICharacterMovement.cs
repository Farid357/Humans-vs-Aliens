namespace HumansVsAliens.Model
{
    public interface ICharacterMovement : IMovement
    {
        bool OnGround { get; }

        void Jump();
    }
}