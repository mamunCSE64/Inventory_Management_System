using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.DTOs
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
        public string Address { get; set; }

    }
}
