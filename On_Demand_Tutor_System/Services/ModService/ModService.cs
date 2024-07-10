using BusinessObjects.Models;
using Repositories.ModRepositories;

namespace Services.ModService
{
    public class ModService : IModService
    {
        private readonly IModRepository _modRepository;

        public ModService()
        {
            _modRepository = new ModRepository();
        }

        public List<Moderator> GetAllMods()
        {
            return _modRepository.GetAllMods();
        }

        public void SaveMod(Moderator mod)
        {
            _modRepository.SaveMod(mod);
        }

        public void UpdateMod(Moderator mod)
        {
            _modRepository.UpdateMod(mod);
        }

        public void DeleteMod(int modId)
        {
            _modRepository.DeleteMod(modId);
        }

        public Moderator GetModById(int modId)
        {
            return _modRepository.GetModById(modId);
        }

        public Moderator GetModByEmail(string modEmail)
        {
            return _modRepository.GetModByEmail(modEmail);
        }
    }
}