using System;

namespace API.Entities
{
    public class AppOrder
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public AppCustomer AppCustomer { get; set; }
        public int DeviceId {get; set;}
        public AppDevice AppDevice {get; set; }
        public DateTime ScheduledDate {get; set;}
        public int OrderStatusId {get; set;}
        public AppOrderStatus AppOrderStatus {get; set;}
        public int OrderTypeId {get; set;}
        public AppOrderType AppOrderType {get; set;}
        public AppCompany AppCompany { get; set; } 
    }
}