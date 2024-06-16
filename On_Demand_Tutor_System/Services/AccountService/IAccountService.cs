using BusinessObjects.DTOs;
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
        Task<(object account, string type)> GetAccount(string email, string password);

        Task<Student> RegisterStudentAsync(StudentRegisterDTO student);

        Task<bool> EmailExistsAsync(string email);
        Task<Tutor> RegisterAsTutor(string email, string password, string fullName, string description, string major);
    }
}
