using BusinessObjects.Enums.User;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ModDAO
    {

        public static List<Moderator> GetAllMods()
        {
            var listMods = new List<Moderator>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listMods = context.Moderators.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listMods;
        }


        public static Moderator GetModByEmail(string modEmail)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Moderators.FirstOrDefault(c => c.Email.Equals(modEmail));
        }


        public static void SaveMod(Moderator mod)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Moderators.Add(mod);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the moderator: " + ex.Message);
            }
        }


        public static void UpdateMod(Moderator mod)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Moderator>(mod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static Moderator GetModById(int modId)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Moderators.FirstOrDefault(c => c.ModId.Equals(modId));
        }


        public static void DeleteMod(int modId)
        {
            using var context = new OnDemandTutorDbContext();
            var student = context.Moderators.FirstOrDefault(c => c.ModId == modId);
            if (student == null)
            {
                throw new InvalidOperationException($"Mod with ID {modId} not found.");
            }
            if (student.Status.Equals(UserStatus.InActive))
            {
                student.Status = UserStatus.Active;
            }
            else
            {
                student.Status = UserStatus.InActive;
            }

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException dbe)
            {
                throw new InvalidOperationException("An error occurred while updating the mod's status.", dbe);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}