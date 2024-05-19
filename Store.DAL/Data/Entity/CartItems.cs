using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Entity
{
	public class CartItems:BaseEntity<int>
	{
		[ForeignKey(nameof(User))]
		public string UserId { get; set; }
		public AppUser User { get; set; }
		public int ProductId { get; set; }
		public string ProductImage { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int Quantity { get; set; }


	}
}
