namespace HumansVsAliens.Gameplay
{
    public interface ICharacterFactory
    {
        ICharacter Create(out IInvulnerability invulnerability);
    }
}