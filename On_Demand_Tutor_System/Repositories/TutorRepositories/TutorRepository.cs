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
    }
}
