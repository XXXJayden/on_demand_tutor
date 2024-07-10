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

        public async Task<(object account, string type, string status)> GetAccount(string email, string password)
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

        public async Task<bool> StudentEmailExistsAsync(string email)
        {
            return await _accountDAO.StudentEmailExistsAsync(email);
        }

        public async Task<bool> TutorEmailExistsAsync(string email)
        {
            return await _accountDAO.TutorEmailExistsAsync(email);
        }

        public async Task<bool> PhoneNumberExistsAsync(string phone)
        {
            return await _accountDAO.StudentPhoneNumberExistsAsync(phone);
        }

        public async Task<Tutor> AddTutorAsync(Tutor tutor)
        {
            return await _accountDAO.AddTutorAsync(tutor);
        }

        public async Task<bool> GenerateAndStoreTokenAsync(string email, string userType, string token)
        {
            return await _accountDAO.GenerateAndStoreTokenAsync(email, userType, token);
        }

        public async Task<bool> ResetPasswordAsync(string token, string userType, string newPassword)
        {
            return await _accountDAO.ResetPasswordAsync(token, userType, newPassword);
        }

        public async Task<string?> GetUserTypeByTokenAsync(string token)
        {
            return await _accountDAO.GetUserTypeByTokenAsync(token);
        }

        public async Task<string?> GetUserTypeByEmailAsync(string email)
        {
            return await _accountDAO.GetUserTypeByEmailAsync(email);
        }

    }
}
