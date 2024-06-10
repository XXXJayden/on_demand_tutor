using BusinessObjects.Models;
using Repositories.AccountRepository;
using Services.Sercurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly PasswordHasher _hasher;
        public AccountService(IAccountRepository accountRepository, PasswordHasher hasher)
        {
            _repo = accountRepository;
            _hasher = hasher;
        }

        public Task<Student> LoginAsStudent(string email, string password)
        {
            return _repo.LoginAsStudent(email, password);
        }

        public Task<Student> RegisterAsStudent(string email, string password)
        {
            password = _hasher.HashPassword(password);
            return _repo.RegisterAsStudent(email, password);
        }
    }
}
