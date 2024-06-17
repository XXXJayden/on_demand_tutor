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
        Task<(object account, string type)> GetAccount(string email, string password);

        Task<Student> RegisterStudentAsync(StudentRegisterDTO student);

        Task<Tutor> RegisterTutorAsync(TutorRegisterDTO tutor);

        Task<bool> EmailExistsAsync(string email);
    }
}
