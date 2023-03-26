namespace Application.Template
{
	public class TemplateDto:TemplateCreateParam
    {
        public Guid TemplateId { get; set; }
        
        public string MainHeaderTextSize { get; set; }
        public string SubHeaderTextsize { get; set; }
        public string HeroImage { get; set; }
        public string Logo { get; set; }
    }
}