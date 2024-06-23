using BusinessObjects.Models;

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
        void DeleteStudent(short studentId);
        Student GetStudentById(int studentId);
    }
}
