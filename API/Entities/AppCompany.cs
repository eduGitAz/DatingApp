using System.Collections.Generic;

namespace API.Entities
{
    public class AppCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string FgazNumber { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}