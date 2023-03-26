namespace Application.Store
{
	public record CreateStoreParam(Guid MerchantId, string storeName, string Currency, string CurrencySymbol);
}