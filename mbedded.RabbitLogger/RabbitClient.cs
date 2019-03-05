using System;
using RabbitMQ.Client;

namespace mbedded.RabbitLogger {

    /// <summary>
    ///     This class creates the connection to the rabbit-service and
    /// </summary>
    public class RabbitClient : IDisposable {

        private readonly string _hostname;
        private readonly string _exchangeName;
        private readonly string _queueName;

        private IModel _channel;

        public RabbitClient(string xHostname, string xExchangeName, string xQueueName) {
            _hostname = xHostname;
            _exchangeName = xExchangeName;
            _queueName = xQueueName;
        }

        public IModel Channel => _channel;

        public string Hostname => _hostname;

        public string ExchangeName => _exchangeName;

        public string QueueName => _queueName;

        public void CreateInfrastructure() {
            ConnectionFactory factory = new ConnectionFactory() {
                HostName = _hostname
            };

            IConnection connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(_exchangeName, "fanout", true, false);

            QueueDeclareOk queue = _channel.QueueDeclare(_queueName, true, false, false);
            _channel.QueueBind(_queueName, _exchangeName, "");
        }

        public void Dispose() {
            _channel.Dispose();
        }

    }

}