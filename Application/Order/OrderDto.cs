﻿namespace Application.Order
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime DateOrdered { get; set; } = DateTime.UtcNow;
        public Decimal TotalAmount { get; set; }
        public string OrderState { get; set; }
    }
}
