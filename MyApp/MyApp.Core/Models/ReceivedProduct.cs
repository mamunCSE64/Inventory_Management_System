using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class ReceivedProduct
    {
        public int Id { get; set; } 
        public int Good { get; set; }
        public int Bad { get; set; }
        public int Missing { get; set; }
        public int WarHouseStockId { get;set; }
        [ForeignKey(nameof(WarHouseStockId))]
        public WareHouseStock WareHouseStock { get; set; }
        public int ProductId { get;set; }
        [ForeignKey(nameof(ProductId))] 
        public Product Product { get; set; }         

    }
}
