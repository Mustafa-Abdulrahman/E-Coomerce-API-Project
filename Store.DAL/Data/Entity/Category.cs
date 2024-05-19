namespace Store.DAL.Data.Entity
{
	public class Category:BaseEntity<int>
	{
		public string Name { get; set; }=string.Empty;
		public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
	}
}