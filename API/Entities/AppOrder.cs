namespace API.Entities
{
    public class AppOrder
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public AppCustomer AppCustomer { get; set; }
        public AppCompany AppCompany { get; set; } 
    }
}