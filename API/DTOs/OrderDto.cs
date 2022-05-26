using System;
using API.Entities;

namespace API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public AppCustomer AppCustomer { get; set; }
        public int? DeviceId {get; set;}
        public virtual AppDevice AppDevice {get; set; }
        public DateTime ScheduledDate {get; set;}
        public int OrderStatusId {get; set;}
        public AppOrderStatus AppOrderStatus {get; set;}
        public int OrderTypeId {get; set;}
        public AppOrderType AppOrderType {get; set;}
        public int? UseOfRefrigernatId {get; set;}
        public virtual AppUseOfRefrigernat AppUseOfRefrigernat {get; set;}
        public int? RefrigerantId {get; set;}
        public virtual AppRefrigerant AppRefrigerant {get; set;}
        public decimal? Weight {get; set;}


    }
}