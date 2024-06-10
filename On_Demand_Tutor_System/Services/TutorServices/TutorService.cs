using BusinessObjects.Models;
using Repositories.TutorRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TutorServices
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorService() { 
        _tutorRepository = new TutorRepository();
        }
        public List<Tutor> GetAllTutor()
        {
            return _tutorRepository.GetAllTutor();
        }
        public void SaveTutor(Tutor tutor)
        {
            _tutorRepository.SaveTutor(tutor);
        }
        public void UpdateTutor(Tutor tutor)
        {
            _tutorRepository.UpdateTutor(tutor);
        }
        public void DeleteTutor(short tutorId)
        {
            _tutorRepository.DeleteTutor(tutorId);
        }
        public Tutor GetTutorById(short tutorId)
        {
            return _tutorRepository.GetTutorById(tutorId);
        }
    }
}
