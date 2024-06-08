using BusinessObjects.Models;

namespace DataAccessLayer
{
    public class TutorDAO
    {
        public static Tutor GetTutorByEmail(string tutorEmail)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Tutors.FirstOrDefault(t => t.Email.Equals(tutorEmail));
        }

        public static List<Tutor> GetAllTutors()
        {
            using var db = new OnDemandTutorDbContext();
            return db.Tutors.ToList();
        }

        public static Tutor GetTutorById(int tutorId)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Tutors.Find(tutorId);
        }

        public static void UpdateTutor(Tutor tutor)
        {
            using var db = new OnDemandTutorDbContext();
            db.Tutors.Update(tutor);
            db.SaveChanges();
        }

        public static void AddTutor(Tutor newTutor)
        {
            using var db = new OnDemandTutorDbContext();
            db.Tutors.Add(newTutor);
            db.SaveChanges();
        }

        public static void DeleteTutor(int tutorId)
        {
            using var db = new OnDemandTutorDbContext();
            var tutor = db.Tutors.Find(tutorId);
            if (tutor != null)
            {
                db.Tutors.Remove(tutor);
                db.SaveChanges();
            }
        }
    }
}
