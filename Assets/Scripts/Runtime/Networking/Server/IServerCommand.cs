namespace HumansVsAliens.Networking
{
    public interface IServerCommand<in TModel>
    {
        void Execute(TModel model);
    }
}