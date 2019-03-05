namespace mbedded.RabbitLogger.Models {

    /// <summary>
    ///     This enum defines different types of messages.
    /// </summary>
    public enum MessageType {

        Trace = 0x00,

        Debug = 0x01,

        Info = 0x10,

        Warning = 0x20,

        Error = 0x30

    }

}