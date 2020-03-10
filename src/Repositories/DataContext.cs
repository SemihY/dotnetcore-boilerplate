using CreditApi.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApi.Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<Credit> Credits { get; set; }

        public DataContext (DbContextOptions options) : base(options) { }
    }
}