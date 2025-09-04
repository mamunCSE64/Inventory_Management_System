namespace Inventory_Management_System.DTOs
{
    public class AddStockProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }   
        public int Good {  get; set; }  
        public int Damage { get; set; } 
        public int Missing { get; set; }    

    }
}
