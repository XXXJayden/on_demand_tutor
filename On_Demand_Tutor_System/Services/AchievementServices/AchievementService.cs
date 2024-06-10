using BusinessObjects.Models;
using Repositories.AchievementRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AchievementServices
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;

        public AchievementService() {
            _achievementRepository = new AchivementRepository();
        }
        public List<Achievement> GetAllAchievement()
        {
            return _achievementRepository.GetAllAchievement();
        }
        public void SaveAchievement(Achievement achievement)
        {
            _achievementRepository.SaveAchievement(achievement);
        }
        public void UpdateAchievement(Achievement achievement)
        {
            _achievementRepository.UpdateAchievement(achievement);
        }
        public void DeleteAchievement(short achievementId)
        {
            _achievementRepository.DeleteAchievement(achievementId);
        }
        public Achievement GetAchievementById(short achievementId) {
            return _achievementRepository.GetAchievementById(achievementId);
        }
    }
}
