using Inventory_Management_System.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class CreateSaleOrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
