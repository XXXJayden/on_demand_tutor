using BusinessObjects.Models;

namespace Repositories.ScheduleRepository
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAllSchedule();
        Schedule GetScheduleById(int id);
        void AddSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        Schedule GetSlotIdByName(string name);

        void DeleteSchedule(Schedule schedule);

        Task<List<string>> GetAvailableSlotsAsync(int tutorId, string date);
    }
}
