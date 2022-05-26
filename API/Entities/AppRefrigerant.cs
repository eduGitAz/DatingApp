using System.Collections.Generic;

namespace API.Entities
{
    public class AppRefrigerant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdrClass { get; set; }
        public ICollection<AppOrder> Orders { get; set; }

    }
}