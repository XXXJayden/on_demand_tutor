using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.StudentRepositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAllStudent() => StudentDAO.GetAllStudent();
        public void SaveStudent(Student student) => StudentDAO.SaveStudent(student);
        public void UpdateStudent(Student student) => StudentDAO.UpdateStudent(student);
        public void DeleteStudent(int studentId) => StudentDAO.DeleteStudent(studentId);
        public Student GetStudentById(int studentId) => StudentDAO.GetStudentById(studentId);
        public Student GetStudentByEmail(string studentEmail) => StudentDAO.GetStudentByEmail(studentEmail);
    }
}