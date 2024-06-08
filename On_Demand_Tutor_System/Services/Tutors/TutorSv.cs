using BusinessObjects.Models;
using Repositories.Tutors;

namespace Services.Tutors
{
    public class TutorSv : ITutorSv
    {
        private readonly ITutorRepository itutorRepository;

        public TutorSv()
        {
            itutorRepository = new TutorRepository();
        }

        public void AddTutor(Tutor tutor)
        {
            itutorRepository.AddTutor(tutor);
        }

        public void DeleteTutor(int tutorId)
        {
            itutorRepository.DeleteTutor(tutorId);
        }

        public List<Tutor> GetTutors()
        {
            return itutorRepository.GetTutors();
        }

        public void UpdateTutor(Tutor tutor)
        {
            itutorRepository.UpdateTutor(tutor);
        }
    }
}
