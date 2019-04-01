using System;
using System.Collections.Generic;
using System.Text;
using mbedded.RabbitLogger.Args;
using mbedded.RabbitLogger.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace mbedded.RabbitLogger {

  public class RabbitReceiver {

    public event EventHandler<LogMessageReceivedEventArgs> MessageReceived;

    private readonly RabbitClient _client;
    private EventingBasicConsumer _consumer;

    public RabbitReceiver(RabbitClient xClient) {
      _client = xClient;
    }

    public void Dispose() {
      _consumer.Received -= ConsumerOnReceived;
      _client.Dispose();
    }

    public void EnableReceive() {
      _consumer = new EventingBasicConsumer(_client.Channel);
      _consumer.Received += ConsumerOnReceived;

      _client.Channel.BasicConsume(_client.QueueName, true, _consumer);
    }

    private void ConsumerOnReceived(object xSender, BasicDeliverEventArgs xArgs) {
      byte[] body = xArgs.Body;
      string message = Encoding.UTF8.GetString(body);

      LogMessage logMessage = JsonConvert.DeserializeObject<LogMessage>(message);
      string appId = xArgs.BasicProperties.AppId;
      
      MessageReceived?.Invoke(this, new LogMessageReceivedEventArgs(logMessage, appId));
    }

  }

}