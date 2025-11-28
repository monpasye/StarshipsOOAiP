namespace StarshipsGame
{
    public interface ICommandInjectable
    {
        void Inject(ICommand command);
    }
}
