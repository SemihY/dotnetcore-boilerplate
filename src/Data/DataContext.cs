using Microsoft.EntityFrameworkCore;
using src.Entities;

namespace CreditApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Credit> Credits { get; set; }

        public DataContext (DbContextOptions options) : base(options) { }
    }
}