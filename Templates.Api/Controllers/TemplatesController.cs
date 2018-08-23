using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Templates.Api.Domain;
using Templates.Api.Models;
using Templates.Api.Repository;

namespace Templates.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateRepository _templateRepository;

        public TemplatesController(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }
        //
        // GET api/templates
        [HttpGet]
        public Task<IActionResult> Get()
        {
            var template = _templateRepository.Query().Select(g => new TemplatesListModel (g.Id , g.TemplateName, g.TemplateDescription) );

            if (template == null) return Task.FromResult<IActionResult>(NotFound());            

            return Task.FromResult<IActionResult>(Ok(template));
        }

        // POST api/templates
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TemplateViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var model = new Template()
                {
                    TemplateBody = entity.TemplateBody,
                    TemplateDescription = entity.TemplateDescription,
                    TemplateName = entity.TemplateName,
                    TemplateVariables = entity.TemplateVariables

                };
                await _templateRepository.InsertAsync(model);
                return Created("",entity);
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .ToList();
                return BadRequest(errors);
            }
        }

        // POST api/templates/5/render
        [HttpPost("{id}/render")]
        public async Task<IActionResult> RenderTemplate(int id)
        {
            var template = await _templateRepository.GetAsync(id);

            if (template == null) return NotFound();

            return Ok(template);
        }
    }
}
