namespace ECommerce.Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string OpenAddress { get; set; }
    }
}