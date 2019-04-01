using System;
using System.Text;
using mbedded.RabbitLogger.Interfaces;
using mbedded.RabbitLogger.Models;
using Newtonsoft.Json;
using RabbitMQ.Client.Framing;

namespace mbedded.RabbitLogger {

  public class RabbitLogger : ILogger {

    private readonly RabbitClient _client;
    private readonly BasicProperties _properties;

    public RabbitLogger(RabbitClient xClient, string xApplicationId) {
      _client = xClient;

      _properties = new BasicProperties() {
        AppId = xApplicationId
      };
    }

    public void Dispose() {
      _client.Dispose();
    }

    public void Debug(string xMessage) {
      LogMessage(MessageType.Debug, xMessage);
    }

    public void Trace(string xMessage) {
      LogMessage(MessageType.Trace, xMessage);
    }

    public void Info(string xMessage) {
      LogMessage(MessageType.Info, xMessage);
    }

    public void Warning(string xMessage) {
      LogMessage(MessageType.Warning, xMessage);
    }

    public void Error(string xMessage) {
      LogMessage(MessageType.Error, xMessage);
    }

    public void Error(string xMessage, Exception xException) {
      LogMessage(MessageType.Error, xMessage, xException);
    }


    private void LogMessage(MessageType xType, string xMessage) {
      LogMessage message = new LogMessage(xType, xMessage);

      PublishMessage(message);
    }

    private void LogMessage(MessageType xType, string xMessage, Exception xException) {
      LogMessage message = new LogMessage(xType, xMessage) {
        Exception = xException
      };

      PublishMessage(message);
    }

    private void PublishMessage(LogMessage xLogMessage) {
      if (string.IsNullOrWhiteSpace(_properties.AppId)) {
        throw new ArgumentException(
          "Application id must not be null or white space. Please specify an ID when you use RabbitLogger-Constructor.");
      }

      string serialized = JsonConvert.SerializeObject(xLogMessage);
      byte[] body = Encoding.UTF8.GetBytes(serialized);

      _client.Channel.BasicPublish(_client.ExchangeName, "", false, _properties, body);
    }

  }

}