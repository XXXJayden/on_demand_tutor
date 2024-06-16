using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Repositories.AccountRepository;
using Services.Sercurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<(object account, string type)> GetAccount(string email, string password)
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
                Grade = registerDTO.Grade,
                Status = registerDTO.Status
            };

            await _repo.AddStudentAsync(student);

            return student;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _repo.EmailExistsAsync(email);
        }

        public Task<Tutor> RegisterAsTutor(string email, string password, string fullName, string description, string major)
        {
            password = _hasher.HashPassword(password);
            return _repo.RegisterAsTutor(email, password, fullName, description, major);
        }
    }
}
