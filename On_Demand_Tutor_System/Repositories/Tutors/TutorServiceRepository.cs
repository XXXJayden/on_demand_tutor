using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.Tutors
{
    public class TutorServiceRepository : ITutorServiceRepository
    {
        public List<TutorService> GetTutorServices() => TutorServiceDAO.GetAllTutorServices();
        public void DeleteTutorService(int id) => TutorServiceDAO.DeleteTutorService(id);
        public void AddTutorService(TutorService tutorService) => TutorServiceDAO.AddTutorService(tutorService);
        public void UpdateTutorService(TutorService tutorService) => TutorServiceDAO.UpdateTutorService(tutorService);
    }
}
