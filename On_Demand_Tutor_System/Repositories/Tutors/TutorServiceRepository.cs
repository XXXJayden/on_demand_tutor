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

        public void AddTutorService()
        {
            throw new NotImplementedException();
        }

        public decimal GetTutorServicePrice(int tutorId, int serviceId)
        {
            return TutorServiceDAO.GetTutorServicePrice(tutorId, serviceId);
        }
        public TutorService GetTutorServiceByServiceId(int id) => TutorServiceDAO.GetTutorServiceByServiceId(id);
    }
}
