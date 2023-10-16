using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SignUpApp.EntityFramework
{
    public class SignUpAppDbContextFactory
    {
        private readonly string _connectionString;

        public SignUpAppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SignUpAppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SignUpAppDbContext>();

            options.UseSqlServer(_connectionString);

            return new SignUpAppDbContext(options.Options);
        }
    }
}
