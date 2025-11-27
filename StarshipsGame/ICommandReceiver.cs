namespace StarshipsGame;

public interface ICommandReceiver
{
    void Receive(ICommand command);
}