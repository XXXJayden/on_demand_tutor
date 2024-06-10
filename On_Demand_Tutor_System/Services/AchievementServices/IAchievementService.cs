using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AchievementServices
{
    public interface IAchievementService
    {
        List<Achievement> GetAllAchievement();
        void SaveAchievement(Achievement achievement);
        void UpdateAchievement(Achievement achievement);
        void DeleteAchievement(short achievementId);
        Achievement GetAchievementById(short achievementId);
    }
}
