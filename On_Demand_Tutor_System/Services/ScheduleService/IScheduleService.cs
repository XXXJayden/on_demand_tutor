using BusinessObjects.Models;

namespace Services.ScheduleService
{
    public interface IScheduleService
    {
        List<Schedule> GetAllSchedule();
        Schedule GetScheduleById(int id);
        void AddSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);

        void DeleteSchedule(Schedule schedule);

        Task<List<string>> GetAvailableSlotsAsync(int tutorId);
    }
}
