using Hwdtech;

namespace StarshipsGame
{
    public class RegisterDependencyCommandInjectableCommand : ICommand
    {
        public void Execute()
        {
            IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Commands.CommandInjectable",
                (object[] args) => new CommandInjectableCommand()
            ).Execute();
        }
    }
}
