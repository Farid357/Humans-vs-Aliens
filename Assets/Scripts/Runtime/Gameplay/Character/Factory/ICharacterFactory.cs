using HumansVsAliens.Networking;

namespace HumansVsAliens.Gameplay
{
    public interface ICharacterFactory
    {
        ICharacter Create(IServer server, out IInvulnerability invulnerability);
    }
}