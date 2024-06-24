using BusinessObjects.Models;
using Repositories.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<List<string>> GetAvailableSlotsAsync(int tutorId, string date)
        {
            return scheduleRepository.GetAvailableSlotsAsync(tutorId, date);
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
