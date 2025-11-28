using NUnit.Framework;
using Moq;

namespace StarshipsGame.Tests;

[TestFixture]
public class SendCommandTests
{
    [Test]
    public void Execute_PassesCommandToReceiver()
    {
        var commandMock = new Mock<ICommand>().Object;
        var receiverMock = new Mock<ICommandReceiver>();

        var sendCommand = new SendCommand(commandMock, receiverMock.Object);

        sendCommand.Execute();

        receiverMock.Verify(r => r.Receive(commandMock), Times.Once);
    }

    [Test]
    public void Execute_ThrowsIfReceiverCannotAcceptCommand()
    {
        var commandMock = new Mock<ICommand>().Object;
        var receiverMock = new Mock<ICommandReceiver>();

        receiverMock
            .Setup(r => r.Receive(It.IsAny<ICommand>()))
            .Throws(new System.InvalidOperationException("Receiver cannot accept"));

        var sendCommand = new SendCommand(commandMock, receiverMock.Object);

        NUnit.Framework.Assert.Throws<System.InvalidOperationException>(() => sendCommand.Execute());
    }
}