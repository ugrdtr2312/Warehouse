using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbSeeds
{
    public static class DbSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, CategoryName = "Juice", Description = "Description how to store juice..."},
                new Category {Id = 2, CategoryName = "Water", Description = "Description how to store water..."},
                new Category {Id = 3, CategoryName = "Soda", Description = "Description how to store soda..."},
                new Category {Id = 4, CategoryName = "Beer", Description = "Description how to store beer..."},
                new Category {Id = 5, CategoryName = "Wine", Description = "Description how to store wine..."},
                new Category {Id = 6, CategoryName = "Whiskey", Description = "Description how to store whiskey..."}
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand{ Id = 1, BrandName = "Sandora"},
                new Brand{ Id = 2, BrandName = "OKZDP"},
                new Brand{ Id = 3, BrandName = "PepsiCo"},
                new Brand{ Id = 4, BrandName = "Coca-Cola Company"},
                new Brand{ Id = 5, BrandName = "Guinness"},
                new Brand{ Id = 6, BrandName = "Hoegaarden"},
                new Brand{ Id = 7, BrandName = "Morshynska"},
                new Brand{ Id = 8, BrandName = "Jameson"},
                new Brand{ Id = 9, BrandName = "Jack Daniel's"},
                new Brand{ Id = 10, BrandName = "French rose"}
            );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier{ Id=1, CompanyName = "Sidorov company", FirstName = "Nikita", Surname = "Sidorov", PhoneNumber = "050-111-11-11"},
                new Supplier{ Id=2, CompanyName = "Stepaniuk warehouse", FirstName = "Ira", Surname = "Stepaniuk", PhoneNumber = "050-222-22-22"},
                new Supplier{ Id=3, CompanyName = "Fedorenko storage", FirstName = "Danial", Surname = "Fedorenko", PhoneNumber = "050-333-33-33"},
                new Supplier{ Id=4, CompanyName = "Dolid delivery", FirstName = "Vova", Surname = "Dolid", PhoneNumber = "050-444-44-44"}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product{ Id = 1, ProductName = "Apple juice 0,5lx12", Amount = 5, Price = 210, BrandId = 1, CategoryId = 1, SupplierId = 4},
                new Product{ Id = 2, ProductName = "Tomato juice 0,5lx12", Amount = 4, Price = 220, BrandId = 2, CategoryId = 1, SupplierId = 1},
                new Product{ Id = 3, ProductName = "Apple juice 1lx12", Amount = 3, Price = 310, BrandId = 2, CategoryId = 1, SupplierId = 3},
                new Product{ Id = 4, ProductName = "Tomato juice 1lx12", Amount = 14, Price = 340, BrandId = 1, CategoryId = 1, SupplierId = 2},
                new Product{ Id = 5, ProductName = "Apple juice 1,5lx12", Amount = 10, Price = 480, BrandId = 1, CategoryId = 1, SupplierId = 1},
                new Product{ Id = 6, ProductName = "Coca-cola 0,5lx12", Amount = 21, Price = 180, BrandId = 4, CategoryId = 3, SupplierId = 2},
                new Product{ Id = 7, ProductName = "Coca-cola 1lx12", Amount = 5, Price = 230, BrandId = 4, CategoryId = 3, SupplierId = 1},
                new Product{ Id = 8, ProductName = "Coca-cola 1,5lx12", Amount = 16, Price = 250, BrandId = 4, CategoryId = 3, SupplierId = 3},
                new Product{ Id = 9, ProductName = "Coca-cola 2lx12", Amount = 12, Price = 270, BrandId = 4, CategoryId = 3, SupplierId = 4},
                new Product{ Id = 10, ProductName = "Pepsi 0,5lx12", Amount = 21, Price = 180, BrandId = 4, CategoryId = 3, SupplierId = 2},
                new Product{ Id = 11, ProductName = "Pepsi 1lx12", Amount = 5, Price = 230, BrandId = 4, CategoryId = 3, SupplierId = 1},
                new Product{ Id = 12, ProductName = "Pepsi 1,5lx12", Amount = 16, Price = 250, BrandId = 4, CategoryId = 3, SupplierId = 3},
                new Product{ Id = 13, ProductName = "Pepsi 2lx12", Amount = 12, Price = 270, BrandId = 4, CategoryId = 3, SupplierId = 4},
                new Product{ Id = 14, ProductName = "Morshynska 0,5lx12", Amount = 14, Price = 120, BrandId = 7, CategoryId = 2, SupplierId = 3},
                new Product{ Id = 15, ProductName = "Mansion No.9", Amount = 3, Price = 600, BrandId = 10, CategoryId = 5, SupplierId = 1},
                new Product{ Id = 16, ProductName = "Hoegaarden 0,5lx12", Amount = 6, Price = 480, BrandId = 6, CategoryId = 4, SupplierId = 1},
                new Product{ Id = 17, ProductName = "Hoegaarden 1lx12", Amount = 13, Price = 680, BrandId = 6, CategoryId = 4, SupplierId = 2},
                new Product{ Id = 18, ProductName = "Guinness 0,435lx12", Amount = 8, Price = 800, BrandId = 5, CategoryId = 4, SupplierId = 1}
               );
        }
    }
}