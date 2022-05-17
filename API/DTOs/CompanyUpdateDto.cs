namespace API.DTOs
{
    public class CompanyUpdateDto
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string FgazNumber { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}