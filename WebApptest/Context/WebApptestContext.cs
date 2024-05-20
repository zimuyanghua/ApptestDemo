using Microsoft.EntityFrameworkCore;

namespace WebApptest.Context
{
    public class WebApptestContext : DbContext
    {
        public WebApptestContext(DbContextOptions<WebApptestContext> options): base(options) { 
        }

        public DbSet<User> User { get; set; }

        //public DbSet<Dept> Dept { get; set; }
    }
}
