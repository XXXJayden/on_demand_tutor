using BusinessObjects.Models;
using Repositories.ScheduleRepository;

namespace Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository scheduleRepository;

        public ScheduleService()
        {
            scheduleRepository = new ScheduleRepository();
        }

        public void AddSchedule(Schedule schedule)
        {
            scheduleRepository.AddSchedule(schedule);
        }

        public void DeleteSchedule(Schedule schedule)
        {
            scheduleRepository.DeleteSchedule(schedule);
        }

        public List<Schedule> GetAllSchedule()
        {
            return scheduleRepository.GetAllSchedule();
        }

        public Task<List<string>> GetAvailableSlotsAsync(int tutorId)
        {
            return scheduleRepository.GetAvailableSlotsAsync(tutorId);
        }

        public Schedule GetScheduleById(int id)
        {
            return scheduleRepository.GetScheduleById(id);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            scheduleRepository.UpdateSchedule(schedule);
        }
    }
}
