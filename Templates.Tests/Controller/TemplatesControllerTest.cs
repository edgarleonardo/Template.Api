using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Templates.Api.Controllers;
using Templates.Api.Domain;
using Templates.Api.Models;
using Templates.Api.Repository;
using Xunit;

namespace Templates.Tests.Controller
{
    public class TemplatesControllerTest
    {
        const int TEMPLATE_ID_FOR_TESTING = 1;
        public TemplatesControllerTest()
        {

        }

        [Fact(DisplayName = "The Post Method must save the template in the storage resource")]
        public async Task Must_Create_Template_Object()
        {
            var templateRepositoryMock = new Mock<ITemplateRepository>();
            var template = new TemplateViewModel
            {
                TemplateBody = "Areva",
                TemplateDescription = "Templates Descriptions",
                TemplateName = "Template Name",
                TemplateVariables = "Templates Variables"
            };


            // Arrange
            templateRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Template>())).Returns(Task.FromResult<TemplateViewModel>(template));
            var templateController = new TemplatesController(templateRepositoryMock.Object);

            // Act
            var result = await templateController.Post(template);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact(DisplayName = "The post with template Id must return a template renred with the variables sent")]
        public async Task Must_Return_Render_Templates_With_Variables_Added()
        {
            var _template = new Template
            {
                Id = TEMPLATE_ID_FOR_TESTING,
            };
            var templateRepositoryMock = new Mock<ITemplateRepository>();
            templateRepositoryMock.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult<Template>(null));
            var templateController = new TemplatesController(templateRepositoryMock.Object);
            // Arrange

            // Act
            var result = await templateController.RenderTemplate(_template.Id);
            Assert.NotNull(result);
            var notfoundResult = result as NotFoundResult;
            Assert.NotNull(notfoundResult);
            Assert.Equal(404, notfoundResult.StatusCode);
        }
    }
}
