namespace API.DTOs
{
    public class CustomerUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}