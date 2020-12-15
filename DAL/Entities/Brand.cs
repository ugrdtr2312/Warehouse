using System.Collections.Generic;

namespace DAL.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}