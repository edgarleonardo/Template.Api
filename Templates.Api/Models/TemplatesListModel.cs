using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.Api.Models
{
    public class TemplatesListModel
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public TemplatesListModel(int id, string templateName, string templateDescription)
        {
            this.TemplateDescription = templateDescription;
            this.TemplateName = templateName;
            this.Id = id;
        }
    }
}
