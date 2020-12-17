namespace DAL.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}