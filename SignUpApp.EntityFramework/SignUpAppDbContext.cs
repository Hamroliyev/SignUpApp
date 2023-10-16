using Microsoft.EntityFrameworkCore;
using SignUpApp.Domain.Models;

namespace SignUpApp.EntityFramework
{
    public class SignUpAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public SignUpAppDbContext(DbContextOptions options) : base(options) { }
    }
}
