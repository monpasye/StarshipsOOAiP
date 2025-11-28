using NUnit.Framework;
using Hwdtech;
using Hwdtech.Ioc;
using StarshipsGame;
using System.Collections.Generic;

namespace StarshipsGame.Tests
{
    [TestFixture]
    public class RegisterIoCDependencyActionsStartTests
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
        public void Execute_RegisterDependency_ActionsStartIsResolved()
        {
            var register = new RegisterIoCDependencyActionsStart();
            register.Execute();

            var order = new Dictionary<string, object> { { "key1", "value1" } };

            var cmd = IoC.Resolve<ICommand>("Actions.Start", order);

            NUnit.Framework.Assert.That(cmd, Is.InstanceOf<StartActionCommand>());
        }
    }
}
