using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        private readonly OnDemandTutorDbContext _context;
        public AccountDAO(OnDemandTutorDbContext context)
        {
            _context = context;
        }


        public async Task<(object account, string type)> GetAccount(string email, string password)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Email == email && s.Password == password);
            if (student != null)
            {
                return (student, "Student");
            }

            var tutor = await _context.Tutors
                .FirstOrDefaultAsync(t => t.Email == email && t.Password == password);
            if (tutor != null)
            {
                return (tutor, "Tutor");
            }

            return (null, string.Empty);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Students.AnyAsync(s => s.Email == email);
        }

        public async Task<Tutor> RegisterAsTutor(string email, string password, string fullName, string description, string major)
        {
            var tutor = new Tutor
            {
                Email = email,
                Password = password,
                Fullname = fullName,
                Description = description,
                Major = major,
                Status = "Active",
                Achievements = null,
                Bookings = null,
                TutorServices = null
            };
            _context.Tutors.Add(tutor);
            await _context.SaveChangesAsync();
            return tutor;
        }

    }
}
