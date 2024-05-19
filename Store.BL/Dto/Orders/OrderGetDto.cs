using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Dto.Orders
{
	public class OrderGetDto
	{

		public int Id { get; set; }
		public string UserId { get; set; } = string.Empty;
		public List<OrderProductsGetDto> OrdersProductsDetails { get; set; }
		public decimal? TotalPrice { get; set; }
		public OrderStatus Status { get; set; } 
		public DateTime OrderDate { get; set; }
		public DateTime? DeliverdDate { get; set; } = DateTime.Now.AddDays(3);

	}
	public class OrderAddDto
	{

		public string UserId { get; set; } = string.Empty;
		public List<OrderProductsGetDto> OrdersProductsDetails { get; set;}
		public decimal? TotalPrice { get; set; }
	}
	public class OrderProductsGetDto
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int OrderId { get; set; }
		public int Quantity { get; set; }
	}
	
}
