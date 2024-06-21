using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StudentServices
{
    public interface IStudentService
    {
        Task<Student> GetStudentByEmailAsync(string email);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task<List<Student>> GetStudentsAsync();
        List<Student> GetAllStudent();
        Student GetStudentByEmail(string studentEmail);
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentById(int studentId);
    }
}
