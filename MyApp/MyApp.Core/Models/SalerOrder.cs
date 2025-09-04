using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class SalerOrder
    {
        public int Id {  get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "pending";
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public int WarHouseId { get; set; }
        [ForeignKey(nameof(WarHouseId))]
        public WarHouse WarHouse { get; set; }    

    }
}
