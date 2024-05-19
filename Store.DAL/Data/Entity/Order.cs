using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Entity
{
	public enum OrderStatus
	{
		pending=0,
		confirmed=1
	}
	public class Order:BaseEntity<int>
	{
		public OrderStatus Status { get; set; } = OrderStatus.pending;
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public DateTime? DeliverdDate { get; set; } = DateTime.Now.AddDays(3);
		public string UserId { get; set; } = string.Empty;
		public AppUser User { get; set; }
		public IEnumerable<OrderProductsDetails> OrdersProductsDetails { get; set; } = new HashSet<OrderProductsDetails>();
		public decimal? TotalPrice { get; set; }


		

	}
}
