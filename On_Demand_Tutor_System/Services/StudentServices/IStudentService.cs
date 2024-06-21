using BusinessObjects.Models;

namespace Services.StudentServices
{
    public interface IStudentService
    {
        List<Student> GetAllStudent();
        Student GetStudentByEmail(string studentEmail);
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentById(int studentId);
    }
}