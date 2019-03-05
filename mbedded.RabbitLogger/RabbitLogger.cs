using System.Text;
using mbedded.RabbitLogger.Interfaces;

namespace mbedded.RabbitLogger {

    public class RabbitLogger : ILogger {

        private readonly RabbitClient _client;

        public RabbitLogger(RabbitClient xClient) {
            _client = xClient;
        }

        public void Dispose() {
            _client.Dispose();
        }

        public void Debug(string xMessage) {
            byte[] body = Encoding.UTF8.GetBytes(xMessage);

            // todo: same exchange as rabbit-client
            _client.Channel.BasicPublish(_client.ExchangeName, "",
                false, null, body);
        }

    }

}