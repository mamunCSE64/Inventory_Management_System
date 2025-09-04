using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Application.DTOs
{
    public class WarHouseStockOpenDto
    {
        public int WarHouseStockId { get; set; }
        public List<AddStockProductDto> CheckProduct { get; set; }  
    }
}
