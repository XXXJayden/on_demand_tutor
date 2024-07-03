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
        Task<(object account, string type, string status)> GetAccount(string email, string password);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> GetStudentByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> PhoneNumberExistsAsync(string phone);
        Task<Tutor> AddTutorAsync(Tutor tutor);
        Task<bool> GenerateAndStoreTokenAsync(string email, string userType, string token);
        Task<bool> ResetPasswordAsync(string token, string userType, string newPassword);
        Task<string?> GetUserTypeByTokenAsync(string token);
        Task<string?> GetUserTypeByEmailAsync(string email);


    }
}
