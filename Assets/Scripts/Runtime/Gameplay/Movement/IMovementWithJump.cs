namespace HumansVsAliens.Gameplay
{
    public interface IMovementWithJump : IMovement
    {
        bool OnGround { get; }

        void Jump();
    }
}