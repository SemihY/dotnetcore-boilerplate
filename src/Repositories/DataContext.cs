using Microsoft.EntityFrameworkCore;
using src.Entities;

namespace CreditApi.Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<Credit> Credits { get; set; }

        public DataContext (DbContextOptions options) : base(options) { }
    }
}