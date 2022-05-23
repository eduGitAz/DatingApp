using System.Collections.Generic;

namespace API.Entities
{
    public class AppOrderStatus
    {
         public int Id { get; set; } 
         public string Name { get; set; } 
         public ICollection<AppOrder> Orders { get; set; }
    }
}