using System;
using mbedded.RabbitLogger.Models;

namespace mbedded.RabbitLogger.Args {

    public class LogMessageReceivedEventArgs : EventArgs {

        /// <summary>
        ///     Creates a new instance with given LogMessage.
        /// </summary>
        /// <param name="xLogMessage">The LogMessage for this event.</param>
        public LogMessageReceivedEventArgs(LogMessage xLogMessage) {
            Message = xLogMessage;
        }

        /// <summary>
        ///     Returns the received LogMessage.
        /// </summary>
        public LogMessage Message { get; }

    }

}