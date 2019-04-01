using mbedded.RabbitLogger.Args;
using mbedded.RabbitLogger.Models;
using Xunit;

namespace mbedded.RabbitLogger.Test.Args {

  public class LogMessageReceivedEventArgsTest {

    [Fact]
    public void CreateInstance() {
      var message = new LogMessage();
      var appId = "the app";

      var target = new LogMessageReceivedEventArgs(message, appId);

      Assert.Equal(message, target.Message);
      Assert.Equal(appId, target.ApplicationId);
    }

  }

}