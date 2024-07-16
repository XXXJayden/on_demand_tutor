using BusinessObjects.Models;
namespace Services.Tutors
{
    public interface ITutorService
    {
        List<TutorService> GetTutorServices();
        void AddTutorService(TutorService tutorService);
        void DeleteTutorService(int id);
        void UpdateTutorService(TutorService tutorService);
        decimal GetTutorServicePrice(int tutorId, int serviceId);
    }
}
