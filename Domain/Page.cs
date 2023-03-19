namespace Domain
{
    public class Page
    {
        public Guid PageId { get; set; }
        public Guid StoreId { get; set; }
        public string MainHearderTextSize { get; set; }
        public string SubHearderTextsize { get; set; }
        public string HeroImage { get; set; }
        public string Logo { get; set; }
        public string HeroMainHearderText { get; set; }
        public string HeroMainSubHearderText { get; set; }
        public string FooterTextHearder { get; set; }
        public string SocialMedia { get; set; }

        public Store Store { get; set; }
    }
}
