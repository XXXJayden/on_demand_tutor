using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.TutorRepositories
{
    public interface ITutorRepository
    {
        List<Tutor> GetAllTutor();
        void SaveTutor(Tutor tutor);
        void UpdateTutor(Tutor tutor);
        void DeleteTutor(short tutorId);
        Tutor GetTutorById(short tutorId);
    }
}
