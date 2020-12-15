using System.Collections.Generic;

namespace DAL.Entities
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}