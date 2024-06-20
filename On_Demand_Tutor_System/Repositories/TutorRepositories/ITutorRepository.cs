using BusinessObjects.Models;

namespace Repositories.TutorRepositories
{
    public interface ITutorRepository
    {
        List<Tutor> GetAllTutor();
        Tutor GetTutorByEmail(string tutorEmail);
        void SaveTutor(Tutor tutor);
        void UpdateTutor(Tutor tutor);
        void DeleteTutor(short tutorId);
        Tutor GetTutorById(short tutorId);
    }
}
