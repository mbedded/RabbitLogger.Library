using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace mbedded.RabbitLogger {

  // TODO 2019-02-11 This class is not working. Callbacks cant be received in an application.
  //  Maybe the client (rabbitMQ) has to be encapsulated if this DLL is used in the same application?
  public class RabbitReceiver {

    // TODO 2019-02-11: Use EventArgs-Class
    public event EventHandler<string> MessageReceived;

    private readonly RabbitClient _client;

    public RabbitReceiver(RabbitClient xClient) {
      _client = xClient;
    }

    public void Dispose() {
      _client.Dispose();
    }

    public void EnableReceive() {
      var queueName = _client.Channel.QueueDeclare().QueueName;

      _client.Channel.QueueBind(queueName, "logs", "");

      var consumer = new EventingBasicConsumer(_client.Channel);
      consumer.Received += ConsumerOnReceived;
      // TODO 2019-02-11: Add "-=" in dispose to avoid memory leak.

      _client.Channel.BasicConsume(queueName, true, consumer);
    }

    private void ConsumerOnReceived(object xSender, BasicDeliverEventArgs xArgs) {
      //_client.Channel.BasicAck(xE.DeliveryTag, false);

      var body = xArgs.Body;
      var message = Encoding.UTF8.GetString(body);

      MessageReceived?.Invoke(this, message);
    }

  }

}
