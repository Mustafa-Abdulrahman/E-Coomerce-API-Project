using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Dto.Cart
{
	
	public class CartItemAddDto
	{
		public string UserId { get; set; }
		public int ProductId { get; set; }
		public string ProductImage { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int Quantity { get; set; }
	}
	public class CartItemGetDto
	{
		public int Id {  get; set; }
		public string UserId { get; set; }
		public int ProductId { get; set; }
		public string ProductImage { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int Quantity { get; set; }
	}
}
