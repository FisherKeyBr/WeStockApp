namespace WeStock.Domain
{
    public class MessageBrokerConstants
    {
        public const string HOST = "localhost";
        public const string DEFAULT_QUEUE = "app";
        public const string COMMAND_REQUESTED_QUEUE = "commandRequested";
        public const string COMMAND_RECEIVED_QUEUE = "commandReceived";
    }
}
