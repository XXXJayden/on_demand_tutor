using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.StudentRepositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDAO _studentDao;

        public StudentRepository(StudentDAO studentDao)
        {
            _studentDao = studentDao;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _studentDao.GetStudentByEmailAsync(email);
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            return await _studentDao.UpdateStudentAsync(student);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentDao.GetStudentByIdAsync(id);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentDao.GetStudentsAsync();
        }
    }
}
