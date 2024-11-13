using Microsoft.EntityFrameworkCore;
using SimpleProductAPI.Model.Domain;

namespace SimpleProductAPI.DataAccess.DataContext
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }
        
       public DbSet <Product> Products { get; set; }
            
        
    }
}
