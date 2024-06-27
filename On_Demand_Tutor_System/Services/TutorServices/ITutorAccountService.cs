using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;

namespace Services.TutorServices
{
    public interface ITutorAccountService
    {
        List<Tutor> GetAllTutor();
        Tutor GetTutorByEmail(string tutorEmail);
        void SaveTutor(Tutor tutor);
        void UpdateTutor(Tutor tutor);
        void DeleteTutor(short tutorId);
        Task<Tutor> GetTutorById(short tutorId);
        Task<List<TutorViewDTO>> GetTutorByIncompleteStatus();
        Task<List<TutorViewDTO>> GetTutorByPendingStatus();
        Task<Tutor> ChangeStatusToIncomplete(int tutorId);
        Task<Tutor> ChangeStatusToPending(int tutorId);
        Task<Tutor> ChangeStatusToActive(int tutorId);


    }
}
