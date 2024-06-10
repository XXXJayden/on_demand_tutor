using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        private readonly OnDemandTutorDbContext _context;
        private AccountDAO(OnDemandTutorDbContext context)
        {
            _context = context;
        }


        public async Task<Student> GetAccountStudent(string email, string password)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email && s.Password == password);
        }

        public async Task<Student> RegisterAsStudent(string email, string password)
        {
            var student = new Student
            {
                Email = email,
                Password = password
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

    }
}
