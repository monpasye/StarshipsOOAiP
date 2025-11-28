using Hwdtech;
using System.Collections.Generic;

namespace StarshipsGame
{
    public class RegisterIoCDependencyActionsStart : ICommand
    {
        public void Execute()
        {
            IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Actions.Start",
                (object[] args) =>
                {
                    var order = args[0] as IDictionary<string, object>;
                    if (order == null)
                        throw new System.ArgumentException("Expected IDictionary<string, object> as argument");

                    return new StartActionCommand(order);
                }
            ).Execute();
        }
    }
}
