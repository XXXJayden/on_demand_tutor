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

        public async Task<(object account, string type)> GetAccount(string email, string password)
        {
            return await _accountDAO.GetAccount(email, password);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _accountDAO.AddStudentAsync(student);
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _accountDAO.GetStudentByEmailAsync(email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _accountDAO.EmailExistsAsync(email);
        }

        public async Task<Tutor> AddTutorAsync(Tutor tutor)
        {
            return await _accountDAO.AddTutorAsync(tutor);
        }


    }
}
