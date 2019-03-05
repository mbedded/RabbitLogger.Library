using System;

namespace mbedded.RabbitLogger.Models {

    /// <summary>
    ///     This class defines a message which is
    ///     exchanged or published via <see cref="RabbitLogger"/>.
    /// </summary>
    public class LogMessage {

        /// <summary>
        ///     Creates a new instance. Uses an empty message
        ///     and <see cref="Debug"/> as default.
        /// </summary>
        public LogMessage() : this(MessageType.Debug, "") {
        }

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        /// <param name="type">Type of this message</param>
        /// <param name="message">Your message.</param>
        public LogMessage(MessageType type, string message) {
            Message = message;
            Type = type;
        }

        /// <summary>
        ///     Gets or sets a custom message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the type of the message.
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        ///     An exception (if applicable).
        /// </summary>
        public Exception Exception { get; set; }

    }

}