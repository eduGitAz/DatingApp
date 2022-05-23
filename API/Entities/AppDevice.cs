using System.Collections.Generic;

namespace API.Entities
{
    public class AppDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public ICollection<AppOrder> Orders { get; set; }
        public AppCompany AppCompany { get; set; }
    }
}