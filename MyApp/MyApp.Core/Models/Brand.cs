using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }

    }
}
