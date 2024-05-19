using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Entity
{
	public class OrderProductsDetails:BaseEntity<int>
	{
		[ForeignKey(nameof(Product))]

		public int ProductId { get; set; }
		public Product Product { get; set; }
		[ForeignKey(nameof(OrderId))]
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public decimal PriceAtThisItem { get; set; }
		public int Quantity { get; set; }
	}
}
