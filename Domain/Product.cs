using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Product
{
    public Guid ProductId { get; set; }
	public string ProductName { get; set; }
	public string ProductDescription { get; set; }
	public string ProductCategory { get; set; }
	public string UnitOfMeasurement { get; set; }
	public int Quantity { get; set; }
	public Guid StoreId { get; set; }
	public Store Store { get; set; }
	public List<Order> Orders { get; set; }

}
