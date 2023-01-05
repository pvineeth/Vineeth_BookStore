using Microsoft.EntityFrameworkCore;
using Vineeth.Data;
using Vineeth.Models;

namespace Vineeth.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppilicationDbcontext context;
        public LanguageRepository(AppilicationDbcontext _context)
        {
            this.context = _context;
        }
        public async Task<List<LanguageModel>> GetAllLanguage()
        {
            return await context.Language.Select(x => new LanguageModel()
            {
                Name = x.Name,
                ID = x.ID,
                Descriptionl = x.Descriptionl

            }).ToListAsync();

        }
    }
}
