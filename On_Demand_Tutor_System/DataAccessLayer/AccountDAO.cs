using BusinessObjects.DTO;
using BusinessObjects.Models;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

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

        public async Task<Tutor> AddTutorAsync(Tutor tutor)
        {
            _context.Tutors.Add(tutor);
            await _context.SaveChangesAsync();
            return tutor;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Students.AnyAsync(s => s.Email == email);
        }

        public async Task<string?> GetUserTypeByTokenAsync(string token)
        {
            token = token.Trim();

            var tokenRecord = await _context.PasswordResetTokens
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Token == token && t.ExpirationDate > DateTime.UtcNow);

            return tokenRecord.UserType;
        }

        public async Task<string?> GetUserTypeByEmailAsync(string email)
        {
            var isStudent = await _context.Students.AnyAsync(s => s.Email == email);
            if (isStudent)
            {
                return "Student";
            }

            var isTutor = await _context.Tutors.AnyAsync(t => t.Email == email);
            if (isTutor)
            {
                return "Tutor";
            }

            return null;
        }


        public async Task<bool> GenerateAndStoreTokenAsync(string email, string userType, string token)
        {
            PasswordResetToken passwordResetToken = null;

            if (userType == "Student")
            {
                var student = await _context.Students.FirstOrDefaultAsync(u => u.Email == email);
                if (student == null) return false;

                passwordResetToken = new PasswordResetToken
                {
                    UserId = student.StudentId,
                    Token = token,
                    ExpirationDate = DateTime.Now.AddHours(24),
                    UserType = userType
                };
            }
            else if (userType == "Tutor")
            {
                var tutor = await _context.Tutors.FirstOrDefaultAsync(u => u.Email == email);
                if (tutor == null) return false;

                passwordResetToken = new PasswordResetToken
                {
                    UserId = tutor.TutorId,
                    Token = token,
                    ExpirationDate = DateTime.Now.AddHours(24),
                    UserType = userType
                };
            }

            if (passwordResetToken != null)
            {
                _context.PasswordResetTokens.Add(passwordResetToken);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ResetPasswordAsync(string token, string userType, string newPassword)
        {
            var tokenRecord = await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.Token == token && t.ExpirationDate > DateTime.Now && t.UserType == userType);

            if (tokenRecord == null)
            {
                return false;
            }

            if (userType == "Student")
            {
                var student = await _context.Students.FindAsync(tokenRecord.UserId);
                if (student == null)
                {
                    return false;
                }

                student.Password = newPassword;
                _context.Students.Update(student);
            }
            else if (userType == "Tutor")
            {
                var tutor = await _context.Tutors.FindAsync(tokenRecord.UserId);
                if (tutor == null)
                {
                    return false;
                }

                tutor.Password = newPassword;
                _context.Tutors.Update(tutor);
            }

            _context.PasswordResetTokens.Remove(tokenRecord);
            await _context.SaveChangesAsync();

            return true;
        }




    }
}
