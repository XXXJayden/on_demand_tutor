using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        Task<Student> LoginAsStudent(string email, string password);
        Task<Student> RegisterAsStudent(string email, string password);
    }
}
