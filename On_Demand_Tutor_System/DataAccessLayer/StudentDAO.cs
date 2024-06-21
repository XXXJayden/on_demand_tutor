using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class StudentDAO
    {
        private readonly OnDemandTutorDbContext _context;
        public StudentDAO(OnDemandTutorDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
        public static List<Student> GetAllStudent()
        {
            var listStudent = new List<Student>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listStudent = context.Students.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listStudent;
        }


        public static Student GetStudentByEmail(string studentEmail)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Students.FirstOrDefault(c => c.Email.Equals(studentEmail));
        }

        public static void SaveStudent(Student student)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Students.Add(student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateStudent(Student student)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Student>(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Student GetStudentById(int studentId)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Students.FirstOrDefault(c => c.StudentId.Equals(studentId));
        }

        public static void DeleteStudent(int studentId)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var student = context.Students.FirstOrDefault(c => c.StudentId == studentId);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
