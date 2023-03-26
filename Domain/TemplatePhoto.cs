namespace Domain
{
	public class TemplatePhoto: Photo
    {
        public Guid TemplateId{get; set;}
        public Template Template {get; set;}
    }
}