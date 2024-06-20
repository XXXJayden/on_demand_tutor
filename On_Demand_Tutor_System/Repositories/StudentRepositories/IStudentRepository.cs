using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.StudentRepositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByEmailAsync(string email);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task<List<Student>> GetStudentsAsync();

    }
}
