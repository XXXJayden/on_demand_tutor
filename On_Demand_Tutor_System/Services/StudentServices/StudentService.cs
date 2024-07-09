using BusinessObjects.Enums.User;
using BusinessObjects.Models;
using Org.BouncyCastle.Asn1.X509;
using Repositories.StudentRepositories;

namespace Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _studentRepository.GetStudentByEmailAsync(email);
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public List<Student> GetAllStudent()
        {
            return _studentRepository.GetAllStudent();
        }

        public Student GetStudentByEmail(string studentEmail)
        {
            return _studentRepository.GetStudentByEmail(studentEmail);
        }

        public void SaveStudent(Student student)
        {
            _studentRepository.SaveStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }

        public void DeleteStudent(short studentId)
        {
            _studentRepository.DeleteStudent(studentId);
        }

        public Student GetStudentById(int studentId)
        {
            return _studentRepository.GetStudentById(studentId);
        }

        public (int ActiveStudent, int InactiveStudent) GetStudentQuantity()
        {
            try
            {
                var student = _studentRepository.GetAllStudent();
                int activeStudent = student.Count(s => s.Status == UserStatus.Active);
                int inactiveStudent = student.Count(s => s.Status == UserStatus.InActive);
                return (activeStudent, inactiveStudent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
