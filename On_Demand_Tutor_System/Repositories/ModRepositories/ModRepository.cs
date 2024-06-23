using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.ModRepositories
{
    public class ModRepository : IModRepository
    {
        public List<Moderator> GetAllMods() => ModDAO.GetAllMods();
        public void SaveMod(Moderator mod) => ModDAO.SaveMod(mod);

        public void UpdateMod(Moderator mod) => ModDAO.UpdateMod(mod);

        public void DeleteMod(int modId) => ModDAO.DeleteMod(modId);

        public Moderator GetModById(int modId) => ModDAO.GetModById(modId);

        public Moderator GetModByEmail(string modEmail) => ModDAO.GetModByEmail(modEmail);
    }
}