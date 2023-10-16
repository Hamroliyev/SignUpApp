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
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SignUpDB;Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
