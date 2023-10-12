using Microsoft.EntityFrameworkCore;
using SignUpApp.Domain.Models;

namespace SignUpApp.EntityFramework
{
    public class SignUpAppDbContext : DbContext
    {
        public SignUpAppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SignUpDB;Trusted_Connection=True;");
        }
    }
}
