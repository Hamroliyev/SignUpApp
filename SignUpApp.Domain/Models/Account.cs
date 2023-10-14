namespace SignUpApp.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
    }
}
