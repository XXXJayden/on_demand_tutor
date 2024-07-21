using BusinessObjects.DTO.Student;
using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;
using Repositories.AccountRepository;
using Services.Sercurity;

namespace Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly PasswordHasher _hasher;
        public AccountService(IAccountRepository accountRepository, PasswordHasher hasher)
        {
            _repo = accountRepository;
            _hasher = hasher;
        }

        public Task<(object account, string type, string status)> GetAccount(string email, string password)
        {
            password = _hasher.HashPassword(password);
            return _repo.GetAccount(email, password);
        }

        public async Task<Student> RegisterStudentAsync(StudentRegisterDTO registerDTO)
        {
            var existingStudent = await _repo.GetStudentByEmailAsync(registerDTO.Email);
            if (existingStudent != null)
            {
                throw new InvalidOperationException("A student with the given email already exists.");
            }

            var hashedPassword = _hasher.HashPassword(registerDTO.Password);

            var student = new Student
            {
                Email = registerDTO.Email,
                Password = hashedPassword,
                Phone = registerDTO.Phone,
                Fullname = registerDTO.FullName,
                Address = registerDTO.Address,
                Grade = registerDTO.Grade.ToString(),
                Status = registerDTO.Status
            };

            await _repo.AddStudentAsync(student);

            return student;
        }

        public async Task<Tutor> RegisterTutorAsync(TutorRegisterDTO registerDTO)
        {
            var hashedPassword = _hasher.HashPassword(registerDTO.Password);

            var tutor = new Tutor
            {
                Email = registerDTO.Email,
                Password = hashedPassword,
                Fullname = registerDTO.Fullname,
                Major = registerDTO.Major.ToString(),
                Status = registerDTO.Status,
                Description = registerDTO.Description,
                Grade = registerDTO.Grade.ToString(),
                Avatar = ""
            };

            await _repo.AddTutorAsync(tutor);

            return tutor;
        }

        public async Task<bool> StudentEmailExistsAsync(string email)
        {
            return await _repo.StudentEmailExistsAsync(email);
        }
        public async Task<bool> TutorEmailExistsAsync(string email)
        {
            return await _repo.TutorEmailExistsAsync(email);
        }

        public async Task<bool> PhoneNumberExistsAsync(string phone)
        {
            return await _repo.PhoneNumberExistsAsync(phone);
        }

        public async Task<bool> ResetPasswordAsync(string token, string userType, string newPassword)
        {
            var hashedPassword = _hasher.HashPassword(newPassword);
            return await _repo.ResetPasswordAsync(token, userType, hashedPassword);
        }

        public async Task<bool> GenerateAndStoreTokenAsync(string email, string userType, string token)
        {
            return await _repo.GenerateAndStoreTokenAsync(email, userType, token);
        }

        public async Task<string?> GetUserTypeByTokenAsync(string token)
        {
            return await _repo.GetUserTypeByTokenAsync(token);
        }

        public async Task<string?> GetUserTypeByEmailAsync(string email)
        {
            return await _repo.GetUserTypeByEmailAsync(email);
        }

    }
}
