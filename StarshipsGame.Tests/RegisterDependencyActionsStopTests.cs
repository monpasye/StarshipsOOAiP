using NUnit.Framework;
using Hwdtech;
using Hwdtech.Ioc;
using System.Collections.Generic;

namespace StarshipsGame.Tests
{
    [TestFixture]
    public class RegisterIoCDependencyActionsStopTests
    {
        [SetUp]
        public void Setup()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();

            var rootScope = IoC.Resolve<object>("Scopes.Root");
            var newScope = IoC.Resolve<object>("Scopes.New", rootScope);

            var setScopeCmd = IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", newScope);
            setScopeCmd.Execute();
        }

        [Test]
        public void Execute_RegisterDependency_ActionsStopIsResolved()
        {
            var registerCommand = new RegisterIoCDependencyActionsStop();
            registerCommand.Execute();

            IDictionary<string, object> order = new Dictionary<string, object>();

            var resolved = IoC.Resolve<Hwdtech.ICommand>("Actions.Stop", order);

            NUnit.Framework.Assert.That(resolved, Is.InstanceOf<StopActionCommand>());

            NUnit.Framework.Assert.DoesNotThrow(() => resolved.Execute());
        }
    }
}
