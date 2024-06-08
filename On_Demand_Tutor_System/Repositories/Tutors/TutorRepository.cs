using BusinessObjects.Models;
using DataAccessLayer;
namespace Repositories.Tutors
{
    public class TutorRepository : ITutorRepository
    {
        public List<Tutor> GetTutors() => TutorDAO.GetAllTutors();
        public void DeleteTutor(int tutorId) => TutorDAO.DeleteTutor(tutorId);
        public void AddTutor(Tutor tutor) => TutorDAO.AddTutor(tutor);
        public void UpdateTutor(Tutor tutor) => TutorDAO.UpdateTutor(tutor);
    }
}