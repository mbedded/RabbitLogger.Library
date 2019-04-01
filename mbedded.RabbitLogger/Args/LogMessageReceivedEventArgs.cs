using System;
using mbedded.RabbitLogger.Models;

namespace mbedded.RabbitLogger.Args {

  public class LogMessageReceivedEventArgs : EventArgs {

    /// <summary>
    ///     Creates a new instance with given LogMessage.
    /// </summary>
    /// <param name="xLogMessage">The LogMessage for this event.</param>
    /// <param name="xAppId">The id of the app which sent the log message.</param>
    public LogMessageReceivedEventArgs(LogMessage xLogMessage, string xAppId) {
      Message = xLogMessage;
      ApplicationId = xAppId;
    }

    /// <summary>
    ///     Returns the received LogMessage.
    /// </summary>
    public LogMessage Message { get; }

    /// <summary>
    ///   The ID of the application which sent the log message.
    /// </summary>
    public string ApplicationId { get; }

  }

}