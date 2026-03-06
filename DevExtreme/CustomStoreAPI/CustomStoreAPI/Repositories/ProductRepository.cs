using CustomStoreAPI.Models;

namespace CustomStoreAPI.Repositories
{
    public class ProductRepository
    {
        public static List<Product> Products = new List<Product>
        {
            new Product{ Id = 1, Name = "Laptop", Price = 70000, Category="Electronics"},
            new Product{ Id = 2, Name = "Phone", Price = 30000, Category="Electronics"},
            new Product{ Id = 3, Name = "Table", Price = 5000, Category="Furniture"},
            new Product{ Id = 4, Name = "Chair", Price = 2000, Category="Furniture"},
            new Product{ Id = 5, Name = "Headphones", Price = 3000, Category="Electronics"},
            new Product{ Id = 6, Name = "Pen", Price = 50, Category="Stationary"},
            new Product{ Id = 7, Name = "Notebook", Price = 100, Category="Stationary"}
        };
    }
}
