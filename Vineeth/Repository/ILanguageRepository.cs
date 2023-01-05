using Vineeth.Models;

namespace Vineeth.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetAllLanguage();
    }
}