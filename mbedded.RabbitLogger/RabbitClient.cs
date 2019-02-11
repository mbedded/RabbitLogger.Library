using System;
using RabbitMQ.Client;

namespace mbedded.RabbitLogger {

  /// <summary>
  ///     This class creates the connection to the rabbit-service and
  /// </summary>
  public class RabbitClient : IDisposable {

    private readonly string _hostName;
    private IModel _channel;

    public RabbitClient(string xHostName) {
      _hostName = xHostName;
    }

    public IModel Channel => _channel;

    public void CreateExchange() {
      ConnectionFactory factory = new ConnectionFactory() {
        HostName = _hostName
      };

      // todo: name for echange via parameter
      IConnection connection = factory.CreateConnection();
      _channel = connection.CreateModel();
      _channel.ExchangeDeclare("logs", "fanout", true, false);
    }

    public void Dispose() {
      _channel.Dispose();
    }

  }

}