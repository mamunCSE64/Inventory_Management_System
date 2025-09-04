namespace Inventory_Management_System.DTOs
{
    public class PurchaseOrderItemDto
    {
        public int SupplierId   { get; set; }   
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
