using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class SaleableProduct
    {
        public int Id { get; set; }
        public int WarHouseId { get; set; }
        [ForeignKey(nameof(WarHouseId))]
        public WareHouseStock WareHouseStock { get; set; }  
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 0;  
    }
}
