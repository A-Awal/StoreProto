namespace Domain
{
    public class Template
    {
        public Guid TemplateId { get; set; }
        public Guid StoreId { get; set; }
        public string main { get; set; }
        public string sub { get; set; }
        public string BgImg { get; set; }
        public string logo { get; set; }
        public string herotext { get; set; }
        public string heroSub { get; set; }
        public string Ftext { get; set; }
        public string SMedia { get; set; }

        public Store Store { get; set; }
    }
}
