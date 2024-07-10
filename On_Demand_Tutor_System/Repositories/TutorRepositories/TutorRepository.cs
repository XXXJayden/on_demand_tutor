using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.TutorRepositories
{
    public class TutorRepository : ITutorRepository
    {
        public List<Tutor> GetAllTutor() => TutorDAO.GetAllTutor();
        public void SaveTutor(Tutor tutor) => TutorDAO.SaveTutor(tutor);
        public void UpdateTutor(Tutor tutor) => TutorDAO.UpdateTutor(tutor);
        public void DeleteTutor(short tutorId) => TutorDAO.DeleteTutor(tutorId);
        public Tutor GetTutorById(short tutorId) => TutorDAO.GetTutorById(tutorId);
        public Tutor GetTutorByEmail(string tutorEmail) => TutorDAO.GetTutorByEmail(tutorEmail);
        public List<Tutor> GetTutorByIncompleteStatus() => TutorDAO.GetTutorByIncompleteStatus();
        public async Task<List<Tutor>> GetTutorByPendingStatus() => await TutorDAO.GetTutorByPendingStatus();
        public Tutor ChangeStatusToPending(int tutorId) => TutorDAO.ChangeStatusToPending(tutorId);
        public Tutor ChangeStatusToIncomplete(int tutorId) => TutorDAO.ChangeStatusToIncomplete(tutorId);
        public Tutor ChangeStatusToActive(int tutorId) => TutorDAO.ChangeStatusToActive(tutorId);
    }
}
