using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace Repositories.AchievementRepositories
{
    public class AchivementRepository : IAchievementRepository
    {
        public List<Achievement> GetAllAchievement() => AchievementDAO.GetAllAchievement();
        public void SaveAchievement(Achievement achievement) => AchievementDAO.SaveAchievement(achievement);
        public void UpdateAchievement(Achievement achievement) => AchievementDAO.UpdateAchievement(achievement);
        public void DeleteAchievement(short achievementId) => AchievementDAO.DeleteAchievement(achievementId);
        public Achievement GetAchievementById(short achievementId) => AchievementDAO.GetAchievementById(achievementId);
    }
}
