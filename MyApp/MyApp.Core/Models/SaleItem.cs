using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
        public int SalerOrderId { get; set; }
        [ForeignKey(nameof(SalerOrderId))]
        public SalerOrder SalerOrder { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
