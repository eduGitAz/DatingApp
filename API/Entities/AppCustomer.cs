namespace API.Entities
{
    public class AppCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public AppCompany AppCompany { get; set; }
    }
}