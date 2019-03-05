using System;
using Newtonsoft.Json;

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
        public LogMessage() : this("") {
        }

        /// <summary>
        ///     Creates a new instance. Uses <see cref="Debug"/> as default.
        /// </summary>
        public LogMessage(string xMessage) : this(MessageType.Debug, xMessage) {
        }

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        /// <param name="type">Type of this message</param>
        /// <param name="message">Your message.</param>
        public LogMessage(MessageType type, string message) {
            CreateDateUtc = DateTime.UtcNow;

            Message = message;
            Type = type;
        }

        /// <summary>
        ///     Gets or sets a custom message.
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the type of the message.
        /// </summary>
        [JsonProperty("Type")]
        public MessageType Type { get; set; }

        /// <summary>
        ///     An exception (if applicable).
        /// </summary>
        [JsonProperty("Exception")]
        public Exception Exception { get; set; }

        /// <summary>
        ///     Datetime (UTC) when this log message was created.
        /// </summary>
        [JsonProperty("Created")]
        public DateTime CreateDateUtc { get; set; }

        public override string ToString() {
            return $"{CreateDateUtc} {Type} - {Message}";
        }

    }

}