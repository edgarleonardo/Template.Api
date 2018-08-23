using Microsoft.EntityFrameworkCore;

namespace Templates.Api.Domain
{
    public class TemplatesDbContext : DbContext
    {
        public TemplatesDbContext()
        {
        }

        public TemplatesDbContext(DbContextOptions<TemplatesDbContext> options) : base(options)
        {
        }

        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
