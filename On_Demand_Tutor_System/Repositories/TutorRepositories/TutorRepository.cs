using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.TutorRepositories
{
    public class TutorRepository :ITutorRepository
    {
        public List<Tutor> GetAllTutor() => TutorDAO.GetAllTutor();
        public void SaveTutor(Tutor tutor) => TutorDAO.SaveTutor(tutor);
        public void UpdateTutor(Tutor tutor) => TutorDAO.UpdateTutor(tutor);
        public void DeleteTutor(short tutorId) => TutorDAO.DeleteTutor(tutorId);
        public Tutor GetTutorById(short tutorId) => TutorDAO.GetTutorById(tutorId);
    }
}
