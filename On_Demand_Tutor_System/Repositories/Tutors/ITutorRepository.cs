using BusinessObjects.Models;

public interface ITutorRepository
{
    List<Tutor> GetTutors();
    void AddTutor(Tutor tutor);
    void DeleteTutor(int tutorId);
    void UpdateTutor(Tutor tutor);
}