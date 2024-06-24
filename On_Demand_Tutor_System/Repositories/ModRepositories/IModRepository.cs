using BusinessObjects.Models;

namespace Repositories.ModRepositories
{
    public interface IModRepository
    {
        List<Moderator> GetAllMods();
        Moderator GetModByEmail(string modEmail);
        void SaveMod(Moderator mod);
        void UpdateMod(Moderator mod);
        void DeleteMod(int modId);
        Moderator GetModById(int modId);
    }
}