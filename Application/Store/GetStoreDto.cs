using Application.Page;

namespace Application.Store
{
    public class GetStoreDto: StoreDto
    {
        public List<PageDto> pages {get; set;}
    }
}