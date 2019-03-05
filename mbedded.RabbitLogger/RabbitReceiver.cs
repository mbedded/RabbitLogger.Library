using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace mbedded.RabbitLogger {

    public class RabbitReceiver {

        // TODO 2019-02-11: Use EventArgs-Class
        public event EventHandler<string> MessageReceived;

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
            var body = xArgs.Body;
            var message = Encoding.UTF8.GetString(body);

            MessageReceived?.Invoke(this, message);
        }

    }

}