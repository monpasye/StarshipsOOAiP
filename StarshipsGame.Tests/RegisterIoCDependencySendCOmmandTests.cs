using Moq;
using Xunit;
using Hwdtech;
using Hwdtech.Ioc;
using StarshipsGame;

namespace StarshipsGame.Tests
{
    public class RegisterIoCDependencySendCommandTests
    {
        public RegisterIoCDependencySendCommandTests()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();

            IoC.Resolve<object>(
                "Scopes.Current.Set",
                IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))
            );
            IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Test.Command",
                (object[] args) => new Mock<StarshipsGame.ICommand>().Object
            ).Execute();

            IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Test.Receiver",
                (object[] args) => new Mock<ICommandReceiver>().Object
            ).Execute();
        }

        [Fact]
        public void Execute_Should_Register_SendCommand()
        {
            var register = new RegisterIoCDependencySendCommand();
            register.Execute();

            var mockCmd = new Mock<StarshipsGame.ICommand>().Object;
            var mockRec = new Mock<ICommandReceiver>().Object;

            var send = IoC.Resolve<SendCommand>(
                "Commands.Send",
                mockCmd,
                mockRec
            );

            Assert.NotNull(send);
            Assert.IsType<SendCommand>(send);
        }
    }
}
