using SignUpApp.Domain.Models;
using System;

namespace SignUpApp.WPF.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged; 
    }
}
