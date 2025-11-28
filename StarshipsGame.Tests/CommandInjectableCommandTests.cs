using NUnit.Framework;
using Moq;
using StarshipsGame;

namespace StarshipsGame.Tests
{
    [TestFixture]
    public class CommandInjectableCommandTests
    {
        [Test]
        public void Execute_CallsInjectedCommand()
        {
            var commandMock = new Mock<ICommand>();
            var injectableCommand = new CommandInjectableCommand();
            injectableCommand.Inject(commandMock.Object);

            injectableCommand.Execute();

            commandMock.Verify(c => c.Execute(), Times.Once);
        }

        [Test]
        public void Execute_WithoutInjection_ThrowsException()
        {
            var injectableCommand = new CommandInjectableCommand();

            NUnit.Framework.Assert.Throws<InvalidOperationException>(() => injectableCommand.Execute());
        }
    }
}
