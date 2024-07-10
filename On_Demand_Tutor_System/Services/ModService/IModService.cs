using BusinessObjects.Models;

namespace Services.ModService
{
    public interface IModService
    {
        List<Moderator> GetAllMods();
        Moderator GetModByEmail(string modEmail);
        void SaveMod(Moderator mod);
        void UpdateMod(Moderator mod);
        void DeleteMod(int modId);
        Moderator GetModById(int modId);
    }
}
