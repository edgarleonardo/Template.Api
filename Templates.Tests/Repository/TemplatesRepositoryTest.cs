using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Templates.Api.Domain;
using Templates.Api.Repository;
using Xunit;

namespace Templates.Tests.Repository
{
    public class TemplatesRepositoryTest
    {
        const int TEMPLATE_ID_FOR_TESTING = 1;
        public TemplatesRepositoryTest()
        {

        }
        [Fact]
        public async Task Add_Template_To_DB()
        {
            var options = new DbContextOptionsBuilder<TemplatesDbContext>()
                .UseInMemoryDatabase(databaseName: "Database")
                .Options;

            using (var context = new TemplatesDbContext(options))
            {
                var template = new Template
                {
                    Id = TEMPLATE_ID_FOR_TESTING,
                    TemplateDescription = "Template Description",
                    TemplateName = "Template Name",
                    TemplateBody = "Template Body",
                    TemplateVariables = "variables"
                };
                var service = new TemplateRepository(context);
                await service.InsertAsync(template);

                var data = await service.GetAsync(TEMPLATE_ID_FOR_TESTING);
                Assert.NotNull(data);
                Assert.Equal(TEMPLATE_ID_FOR_TESTING, data.Id);
            }
        }
        [Fact]
        public async Task Delete_Template_To_DB()
        {
            var options = new DbContextOptionsBuilder<TemplatesDbContext>()
                .UseInMemoryDatabase(databaseName: "Database_2")
                .Options;

            var template = new Template
            {
                Id = TEMPLATE_ID_FOR_TESTING,
                TemplateDescription = "Template Description",
                TemplateName = "Template Name",
                TemplateBody = "Template Body",
                TemplateVariables = "variables"
            };

            using (var context = new TemplatesDbContext(options))
            {
                var service = new TemplateRepository(context);
                await service.InsertAsync(template);


                var result = await service.GetAsync(TEMPLATE_ID_FOR_TESTING);
                Assert.NotNull(result);
                Assert.Equal(TEMPLATE_ID_FOR_TESTING, result.Id);


                await service.UpdateAsync(template);
                result = await service.GetAsync(TEMPLATE_ID_FOR_TESTING);
                Assert.Equal(TEMPLATE_ID_FOR_TESTING, result.Id);
            }
        }
        [Fact]
        public async Task Find_Element_On_DB()
        {
            var options = new DbContextOptionsBuilder<TemplatesDbContext>()
                .UseInMemoryDatabase(databaseName: "Database_3")
                .Options;

            using (var context = new TemplatesDbContext(options))
            {
                var template = new Template
                {
                    Id = TEMPLATE_ID_FOR_TESTING,
                    TemplateDescription = "Template Description",
                    TemplateName = "Template Name",
                    TemplateBody = "Template Body",
                    TemplateVariables = "variables"
                };
                var service = new TemplateRepository(context);
                await service.InsertAsync(template);

                var result = await service.GetAsync(TEMPLATE_ID_FOR_TESTING);
                Assert.NotNull(result);
                Assert.Equal(TEMPLATE_ID_FOR_TESTING, result.Id);
                var resultsUsingQueryable = service.Query().Where(g => g.Id == TEMPLATE_ID_FOR_TESTING
                ).FirstOrDefault();
                Assert.NotNull(resultsUsingQueryable);
                Assert.Equal(TEMPLATE_ID_FOR_TESTING, resultsUsingQueryable.Id);
            }
        }
    }
}
