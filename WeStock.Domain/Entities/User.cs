namespace WeStock.Domain.Entities
{
    public class User : IEntity
    {
        public object Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}
