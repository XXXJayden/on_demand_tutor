using BusinessObjects.Models;

namespace Services.Tutors
{
    public interface ITutorSv
    {
        List<Tutor> GetTutors();
        void AddTutor(Tutor tutor);
        void DeleteTutor(int tutorId);
        void UpdateTutor(Tutor tutor);
    }
}
