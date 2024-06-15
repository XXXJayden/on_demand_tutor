using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO _accountDAO;
        public AccountRepository(AccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }
        public async Task<Student> LoginAsStudent(string email, string password)
        {
            return await _accountDAO.GetAccountStudent(email, password);
        }

        public async Task<Student> RegisterAsStudent(string email, string password)
        {
           return await _accountDAO.RegisterAsStudent(email, password);
        }
    }
}
