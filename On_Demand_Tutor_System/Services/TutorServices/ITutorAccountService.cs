using BusinessObjects.Models;

namespace Services.TutorServices
{
    public interface ITutorAccountService
    {
        List<Tutor> GetAllTutor();
        Tutor GetTutorByEmail(string tutorEmail);
        void SaveTutor(Tutor tutor);
        void UpdateTutor(Tutor tutor);
        void DeleteTutor(short tutorId);
        Tutor GetTutorById(short tutorId);
    }
}
