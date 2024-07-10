using BusinessObjects.DTO.Student;
using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountService
{
    public interface IAccountService
    {
        Task<(object account, string type, string status)> GetAccount(string email, string password);

        Task<Student> RegisterStudentAsync(StudentRegisterDTO student);

        Task<Tutor> RegisterTutorAsync(TutorRegisterDTO tutor);

        Task<bool> StudentEmailExistsAsync(string email);
        Task<bool> TutorEmailExistsAsync(string email);
        Task<bool> PhoneNumberExistsAsync(string phone);
        Task<bool> GenerateAndStoreTokenAsync(string email, string userType, string token);
        Task<bool> ResetPasswordAsync(string token, string userType, string newPassword);

        Task<string?> GetUserTypeByTokenAsync(string token);

        Task<string?> GetUserTypeByEmailAsync(string email);

    }
}
