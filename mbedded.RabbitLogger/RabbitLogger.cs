using System.Text;
using mbedded.RabbitLogger.Interfaces;

namespace mbedded.RabbitLogger {

  public class RabbitLogger : ILogger {
    private readonly RabbitClient _client;

    public RabbitLogger(RabbitClient xClient) {
      _client = xClient;
    }

    public void Dispose() {
      throw new System.NotImplementedException();
    }

    public void Debug(string message) {

      byte[] body = Encoding.UTF8.GetBytes(message);
      
      // todo: same exchange as rabbit-client
      _client.Channel.BasicPublish("logs","",
        false, null, body);
      
      throw new System.NotImplementedException();
    }

  }

}
