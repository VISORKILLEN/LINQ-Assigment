using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Assigment.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
