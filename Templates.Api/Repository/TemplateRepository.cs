using Templates.Api.Domain;

namespace Templates.Api.Repository
{
    public class TemplateRepository : GenericRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(TemplatesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
