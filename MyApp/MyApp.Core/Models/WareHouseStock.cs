using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class WareHouseStock
    {
        public int Id { get; set; } 
        public int WarHouseID { get; set; }
        [ForeignKey(nameof(WarHouseID))]
        public WarHouse Warhouse { get; set; }    
        public int PurchaseOrderID { get; set; }
        [ForeignKey(nameof(PurchaseOrderID))]
        public PurchaseOrder PurchaseOrder { get; set; }    
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "pending";
    }
}
