using System;

namespace mbedded.RabbitLogger.Interfaces {

  public interface ILogger : IDisposable {

    void Debug(string xMessage);
    //void Info(string message);
    //void Warning(string message);
    //void Error(string message);
    //void Error(Exception exception, string message);


  }

}