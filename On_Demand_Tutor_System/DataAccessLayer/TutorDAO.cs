using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class TutorDAO
    {
        public static List<Tutor> GetAllTutor()
        {
            var listTutor = new List<Tutor>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listTutor = context.Tutors.Include(x => x.TutorServices)
                    .ThenInclude(sv => sv.Service).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listTutor;
        }
        public static Tutor GetTutorByEmail(string tutorEmail)
        {
            using var db = new OnDemandTutorDbContext();
            return
                db.Tutors.FirstOrDefault(c => c.Email.Equals(tutorEmail));
        }
        public static void SaveTutor(Tutor tutor)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Tutors.Add(tutor);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateTutor(Tutor tutor)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Tutor>(tutor).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Tutor GetTutorById(int tutorId)
        {
            using var context = new OnDemandTutorDbContext();
            return context.Tutors
                            .Include(t => t.TutorServices)
                             .ThenInclude(ts => ts.Service)
                            .Include(t => t.Achievements)
                            .FirstOrDefault(t => t.TutorId == tutorId);
        }
        public static void DeleteTutor(short tutorId)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var tutor = context.Tutors.FirstOrDefault(c => c.TutorId == tutorId);
                if (tutor != null)
                {
                    context.Tutors.Remove(tutor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
