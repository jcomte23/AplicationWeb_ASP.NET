using System.ComponentModel.DataAnnotations;

namespace WebApplicationCRUD_USERS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set;}
        public DateOnly ExpirationDate { get; set; }
    }
}
