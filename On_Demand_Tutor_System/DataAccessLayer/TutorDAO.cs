
using BusinessObjects.Enums.User;
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
            using var context = new OnDemandTutorDbContext();
            var tutor = context.Tutors.FirstOrDefault(c => c.TutorId == tutorId);
            if (tutor == null)
            {
                throw new InvalidOperationException($"Tutor with ID {tutorId} not found.");
            }
            tutor.Status = UserStatus.InActive;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException dbe)
            {
                throw new InvalidOperationException("An error occurred while updating the tutor's status.", dbe);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public static List<Tutor> GetTutorByIncompleteStatus()
        {
            using var db = new OnDemandTutorDbContext();
            return db.Tutors.Where(c => c.Status == "Incomplete").ToList();
        }

        public static async Task<List<Tutor>> GetTutorByPendingStatus()
        {
            using var db = new OnDemandTutorDbContext();
            return db.Tutors.Where(c => c.Status == "Pending").ToList();
        }

        public static Tutor ChangeStatusToPending(int tutorId)
        {
            using var db = new OnDemandTutorDbContext();
            var tutor = db.Tutors.FirstOrDefault(c => c.TutorId == tutorId);
            if (tutor != null)
            {
                tutor.Status = "Pending";
                db.SaveChanges();
            }
            return tutor;
        }
        public static Tutor ChangeStatusToIncomplete(int tutorId)
        {
            using var db = new OnDemandTutorDbContext();
            var tutor = db.Tutors.FirstOrDefault(c => c.TutorId == tutorId);
            if (tutor != null)
            {
                tutor.Status = "Incomplete";
                db.SaveChanges();
            }
            return tutor;
        }
        public static Tutor ChangeStatusToActive(int tutorId)
        {
            using var db = new OnDemandTutorDbContext();
            var tutor = db.Tutors.FirstOrDefault(c => c.TutorId == tutorId);
            if (tutor != null)
            {
                if (tutor.Status.Equals(UserStatus.Active))
                {
                    tutor.Status = UserStatus.InActive;
                    db.SaveChanges();
                }
                else if (tutor.Status.Equals(UserStatus.InActive))
                {
                    tutor.Status = UserStatus.Active;
                    db.SaveChanges();
                }
            }
            return tutor;
        }

    }
}
