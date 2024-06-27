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
        List<Tutor> GetTutorByIncompleteStatus();
        Task<List<Tutor>> GetTutorByPendingStatus();
        Tutor ChangeStatusToIncomplete(int tutorId);
        Tutor ChangeStatusToPending(int tutorId);
        Tutor ChangeStatusToActive(int tutorId);


    }
}
