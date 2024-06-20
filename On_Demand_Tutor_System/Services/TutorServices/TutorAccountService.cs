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
    }
}
