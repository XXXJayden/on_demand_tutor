using BusinessObjects.Models;
using Repositories.Tutors;

namespace Services.Tutors
{
    public class TutorServices : ITutorService
    {
        private readonly ITutorServiceRepository tutorServiceRepository;


        public TutorServices()
        {
            tutorServiceRepository = new TutorServiceRepository();
        }

        public void AddTutorService(TutorService tutorService)
        {
            tutorServiceRepository.AddTutorService(tutorService);
        }

        public void DeleteTutorService(int id)
        {
            tutorServiceRepository.DeleteTutorService(id);
        }

        public List<TutorService> GetTutorServices()
        {
            return tutorServiceRepository.GetTutorServices();
        }

        public void UpdateTutorService(TutorService tutorService)
        {
            tutorServiceRepository.UpdateTutorService(tutorService);
        }
        public TutorService GetTutorServiceByServiceId(int id)
        {
            return tutorServiceRepository.GetTutorServiceByServiceId(id);
        }

    }
}
