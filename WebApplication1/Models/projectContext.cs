using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class projectContext : DbContext
    {
        public projectContext(DbContextOptions<projectContext> options) : base(options) { }

        public DbSet<tblCity> tblCitie { get; set; }
        public DbSet<tblCustomers> tblCustomers { get; set; }
    }
}
