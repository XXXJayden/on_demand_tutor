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
        Task<(object account, string type)> GetAccount(string email, string password);

        Task<Student> AddStudentAsync(Student student);

        Task<Student> GetStudentByEmailAsync(string email);

        Task<bool> EmailExistsAsync(string email);

        Task<Tutor> AddTutorAsync(Tutor tutor);
    }
}
