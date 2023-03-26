namespace Domain
{
	public class Template
    {
        public Guid TemplateId { get; set; }
        public string TemplateCategory { get; set; }
        public int TemplateNumber { get; set; }
        public string MainHeaderTextSize { get; set; }
        public string SubHeaderTextsize { get; set; }
        public string HeroImage { get; set; }
        public string Logo { get; set; }
        public string Heading{ get; set; }
        public string SubHeading { get; set; }
        public string MainColor{ get; set; }
        public string SubColor { get; set; }
        public string FooterText{ get; set; }
        public string Address{ get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string PhoneNumber { get; set; }
        public string StoreName { get; set; }
        public ICollection<TemplatePhoto> TemplatePhotos { get; set; }

    }
}