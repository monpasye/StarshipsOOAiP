using NUnit.Framework;
using Hwdtech;
using StarshipsGame;
using Hwdtech.Ioc;

namespace StarshipsGame.Tests
{
    [TestFixture]
    public class RegisterDependencyCommandInjectableCommandTests
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
        public void Execute_RegisterDependency_commandInjectableIsResolved()
        {
            var registerCommand = new RegisterDependencyCommandInjectableCommand();
            registerCommand.Execute();

            var asICommand = IoC.Resolve<ICommand>("Commands.CommandInjectable");
            NUnit.Framework.Assert.That(asICommand, Is.InstanceOf<CommandInjectableCommand>());

            var asICommandInjectable = IoC.Resolve<ICommandInjectable>("Commands.CommandInjectable");
            NUnit.Framework.Assert.That(asICommandInjectable, Is.InstanceOf<CommandInjectableCommand>());

            var asConcrete = IoC.Resolve<CommandInjectableCommand>("Commands.CommandInjectable");
            NUnit.Framework.Assert.That(asConcrete, Is.InstanceOf<CommandInjectableCommand>());
        }
    }
}
