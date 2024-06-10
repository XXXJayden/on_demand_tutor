using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AchievementDAO
    {
        public static List<Achievement> GetAllAchievement()
        {
            var listAchievement = new List<Achievement>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listAchievement = context.Achievements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAchievement;
        }
        public static void SaveAchievement(Achievement achievement)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Achievements.Add(achievement);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAchievement(Achievement achievement)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Achievement>(achievement).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Achievement GetAchievementById(int achievementId)
        {
            using var db = new OnDemandTutorDbContext();
            return
                db.Achievements.FirstOrDefault(c => c.AchievementId.Equals(achievementId));
        }
        public static void DeleteAchievement(short achievementId)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var achievement = context.Achievements.FirstOrDefault(c => c.AchievementId == achievementId);
                if (achievement != null)
                {
                    context.Achievements.Remove(achievement);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
