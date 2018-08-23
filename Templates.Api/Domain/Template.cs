using System;

namespace Templates.Api.Domain
{
    public class Template
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public string TemplateVariables { get; set; }
        public string TemplateBody { get; set; }
        public DateTime CreationDate { get; set; }
        public Template ()
        {
            CreationDate = DateTime.Now;
        }
    }
}
