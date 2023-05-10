namespace WeStock.Domain.MessagePackets
{
    public class ConnectionContext
    {
        public long UserId { get; set; }
        public string DisplayName { get; set; }
        public string ConnectionId { get; set; }
    }
}