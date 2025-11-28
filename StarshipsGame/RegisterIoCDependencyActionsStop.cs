using System.Collections.Generic;
using Hwdtech;

namespace StarshipsGame
{
    public class RegisterIoCDependencyActionsStop : Hwdtech.ICommand
    {
        public void Execute()
        {
            IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Actions.Stop",
                (object[] args) => new StopActionCommand((IDictionary<string, object>)args[0])
            ).Execute();
        }
    }
}
