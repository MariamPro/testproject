using asp_pro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class entity_context :DbContext
    {
        public entity_context(DbContextOptions options) : base(options)
        {  
            
         }

        public DbSet<Category>? _category { get; set; }
        public DbSet<Products>? _product { get; set; }
        public DbSet<User>? users { get; set; }  

    }

}
