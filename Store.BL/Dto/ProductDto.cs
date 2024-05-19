using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Dto
{
	public class ProductGet
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
	}

	public class ProductSet
	{

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int CategoryId { get; set; }

	}
	public class ProductUpdate
	{

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int CategoryId { get; set; }

	}
	public class ProductDelete
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int CategoryId { get; set; }

	}
}
