using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category ProductCategory { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public  Brand Brand {get;set;}

    }
}
