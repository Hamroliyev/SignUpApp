using SignUpApp.Domain.Models;
using System.Threading.Tasks;

namespace SignUpApp.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string userName);
        Task<Account> GetByEmail(string email);
    }
}
