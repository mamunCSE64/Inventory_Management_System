using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Inventory_Management_System.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get;set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        public PurchaseOrder PurchaseOrder { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "pending";
    }
}
