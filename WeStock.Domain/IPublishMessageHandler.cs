namespace WeStock.Domain
{
    public interface IPublishMessageHandler : IDisposable
    {
        void Publish<T>(T message, string queue = MessageBrokerConstants.DEFAULT_QUEUE) where T: class, new();
    }
}