using API.Entities;

namespace API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public AppCustomer appCustomer { get; set; }
    }
}