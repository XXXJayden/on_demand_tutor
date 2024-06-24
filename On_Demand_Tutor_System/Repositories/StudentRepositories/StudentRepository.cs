using BusinessObjects.Models;
using DataAccessLayer;

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
        public List<Student> GetAllStudent() => StudentDAO.GetAllStudent();
        public void SaveStudent(Student student) => StudentDAO.SaveStudent(student);
        public void UpdateStudent(Student student) => StudentDAO.UpdateStudent(student);
        public void DeleteStudent(short studentId) => StudentDAO.DeleteStudent(studentId);
        public Student GetStudentById(int studentId) => StudentDAO.GetStudentById(studentId);
        public Student GetStudentByEmail(string studentEmail) => StudentDAO.GetStudentByEmail(studentEmail);
    }
}
