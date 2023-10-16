using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SignUpApp.EntityFramework
{
    public class SignUpAppDbContextFactory
    {
        public SignUpAppDbContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder<SignUpAppDbContext> options = new DbContextOptionsBuilder<SignUpAppDbContext>();

            options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SignUpDB;Integrated Security=True;Connect Timeout=30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new SignUpAppDbContext(options.Options);
        }
    }
}
