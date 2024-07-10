using BusinessObjects.DTO.Tutor;
using BusinessObjects.Enums.User;
using BusinessObjects.Models;
using Repositories.TutorRepositories;

namespace Services.TutorServices
{
    public class TutorAccountService : ITutorAccountService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorAccountService()
        {
            _tutorRepository = new TutorRepository();
        }
        public List<Tutor> GetAllTutor()
        {
            return _tutorRepository.GetAllTutor();
        }
        public void SaveTutor(Tutor tutor)
        {
            _tutorRepository.SaveTutor(tutor);
        }
        public void UpdateTutor(Tutor tutor)
        {
            _tutorRepository.UpdateTutor(tutor);
        }
        public void DeleteTutor(short tutorId)
        {
            _tutorRepository.DeleteTutor(tutorId);
        }
        public Tutor GetTutorById(short tutorId)
        {
            return _tutorRepository.GetTutorById(tutorId);
        }

        public Tutor GetTutorByEmail(string tutorEmail)
        {
            return _tutorRepository.GetTutorByEmail(tutorEmail);
        }

        public async Task<List<TutorViewDTO>> GetTutorByIncompleteStatus()
        {
            var tutors = _tutorRepository.GetTutorByIncompleteStatus();
            return tutors.Select(tutor => new TutorViewDTO
            {
                TutorId = tutor.TutorId,
                FullName = tutor.Fullname,
                Email = tutor.Email,
                Grade = tutor.Grade,
                Status = tutor.Status,
                Major = tutor.Major
            }).ToList();
        }

        public async Task<List<TutorViewDTO>> GetTutorByPendingStatus()
        {
            var tutors = await _tutorRepository.GetTutorByPendingStatus();
            return tutors.Select(tutor => new TutorViewDTO
            {
                TutorId = tutor.TutorId,
                FullName = tutor.Fullname,
                Email = tutor.Email,
                Grade = tutor.Grade,
                Status = tutor.Status,
                Major = tutor.Major
            }).ToList();
        }

        public async Task<Tutor> ChangeStatusToIncomplete(int tutorId)
        {
            return _tutorRepository.ChangeStatusToIncomplete(tutorId);
        }

        public async Task<Tutor> ChangeStatusToPending(int tutorId)
        {
            return _tutorRepository.ChangeStatusToPending(tutorId);
        }

        public async Task<Tutor> ChangeStatusToActive(int tutorId)
        {
            return _tutorRepository.ChangeStatusToActive(tutorId);
        }

        public (int ActiveTutor, int InactiveTutor) GetTutorQuantity()
        {
            try
            {
                var tutor = _tutorRepository.GetAllTutor();
                int activeTutor = tutor.Count(s => s.Status == UserStatus.Active);
                int inactiveTutor = tutor.Count(s => s.Status == UserStatus.InActive);
                return (activeTutor, inactiveTutor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
