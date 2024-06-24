using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ScheduleRepository
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAllSchedule();
        Schedule GetScheduleById(int id);
        void AddSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);

        void DeleteSchedule(Schedule schedule);

        Task<List<string>> GetAvailableSlotsAsync(int tutorId, string date);
    }
}
