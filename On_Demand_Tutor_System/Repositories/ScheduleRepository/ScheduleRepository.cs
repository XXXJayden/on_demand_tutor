using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.ScheduleRepository
{
    public class ScheduleRepository : IScheduleRepository
    {
        public void AddSchedule(Schedule schedule)
        => ScheduleDAO.AddSchedule(schedule);

        public void DeleteSchedule(Schedule schedule)
            => ScheduleDAO.DeleteSchedule(schedule);

        public List<Schedule> GetAllSchedule()
            => ScheduleDAO.GetAllSchedule();

        public Task<List<string>> GetAvailableSlotsAsync(int tutorId)
            => ScheduleDAO.GetAvailableSlotsAsync(tutorId);

        public Schedule GetScheduleById(int id)
            => ScheduleDAO.GetScheduleById(id);

        public void UpdateSchedule(Schedule schedule)
            => ScheduleDAO.UpdateSchedule(schedule);
    }
}
