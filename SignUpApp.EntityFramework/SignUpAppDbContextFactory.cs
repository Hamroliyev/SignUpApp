using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

            return new SignUpAppDbContext(options.Options);
        }
    }
}
