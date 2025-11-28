using Hwdtech;

namespace StarshipsGame;

public class RegisterIoCDependencySendCommand : ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Commands.Send",
            (object[] args) => new SendCommand((ICommand)args[0], (ICommandReceiver)args[1])
        ).Execute();
    }
}
