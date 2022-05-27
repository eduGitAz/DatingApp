using System;

namespace API.DTOs
{
    public class OrderUpdateDto
    {
        public int CustomerId { get; set; }
        public int DeviceId {get; set;}
        public DateTime ScheduledDate {get; set;}
        public int OrderStatusId {get; set;}
        public int OrderTypeId {get; set;}
        public int? UseOfRefrigernatId {get; set;}
        public int? RefrigerantId {get; set;}
        public decimal? Weight {get; set;}
    }
}